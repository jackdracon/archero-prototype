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

    //Coroutine applied to smooth the object
    private Coroutine smoothMoveCoroutine;

    private Vector3? targetPosition;

    private void Awake()
    {
        input = GetComponent<InputReader>();        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Move object
    void Move()
    {
        //var _position = input.MoveInput();
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
}
