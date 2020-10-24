using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy's value
/// </summary>
public class Enemy : Entity
{
    //Player entity reference
    private Player playerEntity;

    private void Start()
    {
        playerEntity = GameObject.FindObjectOfType<Player>();
        
    }

    private void Update()
    {
        if (playerEntity && canShoot)
        {
            float _distancePlayer = Vector3.Distance(transform.position, playerEntity.transform.position);
            if(_distancePlayer <= distance)
            {
                var _shotCommand = new ShotCommand(this, playerEntity.transform);
                _shotCommand.Execute();
            }
        }
    }

    //Shot on target 
    public override void ShotTarget(Transform _target)
    {
        canShoot = false;

    }
}
