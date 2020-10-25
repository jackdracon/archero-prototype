using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player's value 
/// </summary>
[RequireComponent(typeof(InputReader))]
public class Player : Entity
{
    //Input Reader values
    private InputReader input;

    //Current Weapon to be used
    private Weapon myWeapon;

    //Coroutine applied to smooth the object
    private Coroutine smoothMoveCoroutine;

    //Target direction
    private Vector3? targetPosition;

    private void Awake()
    {
        myWeapon = GetComponent<Weapon>();
        input = GetComponent<InputReader>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(CurrentState == STATE.STANDING)
            OnShot();
    }

    //Closest Enemy to player
    Enemy SeekClosestEnemy()
    {
        var _aliveEnemies = GameObject.FindObjectsOfType<Enemy>();
        Enemy _closestEnemy = null;
        foreach (Enemy _enemy in _aliveEnemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, _enemy.transform.position);
            if(enemyDistance < distance)
            {
                _closestEnemy = _enemy;
            }
        }

        return _closestEnemy;
    }
    //Shot action to apply the shot command when its possible to shoot and found a closest enemy
    private void OnShot()
    {
        if (canShoot)
        {
            Enemy _currentTarget = SeekClosestEnemy();
            if (_currentTarget)
            {
                ShotCommand _shotCommand = new ShotCommand(this, _currentTarget.transform);
                _shotCommand.Execute();
                
                //look to the current enemy
                transform.LookAt(_currentTarget.transform);
            }
        }
    }

    //Move object
    void Move()
    {
        targetPosition = input.MoveInput();
        if (targetPosition != null)
        {
            var _move = new MoveCommand(targetPosition.Value, this);
            _move.Execute();
        }
    }

    //override the original method related to make moviment
    public override void MoveTo(Vector3 _startPosition, Vector3 _targetDestination)
    {
        if (smoothMoveCoroutine != null)
            StopCoroutine(smoothMoveCoroutine);
        
        CurrentState = STATE.WALKING;

        smoothMoveCoroutine = StartCoroutine(SmoothMoveAsync(_startPosition, _targetDestination));
    }

    //Async method related to apply a smooth moviment
    private IEnumerator SmoothMoveAsync(Vector3 _from, Vector3 _to)
    {
        float _elapsed = 0;
        while(_elapsed < 1f)
        {
            transform.position = Vector3.Lerp(_from, _to, _elapsed);
            _elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = _to;
        CurrentState = STATE.STANDING;
    }

    //Shot on target 
    public override void ShotTarget(Transform _target)
    {
        if (myWeapon.weaponStatus == WEAPONSTATUS.STAND)
        {
            myWeapon.Shot();
        }
    }
}
