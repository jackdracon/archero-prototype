using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy's value
/// </summary>
public class Enemy : Entity
{
    public static event Action<Enemy> OnDie;

    //Player entity reference
    private Player playerEntity;
    
    //Weapon 
    private Weapon myWeapon;

    private void Start()
    {
        myWeapon = GetComponent<Weapon>();
        playerEntity = GameObject.FindObjectOfType<Player>();
        canShoot = true;
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

                transform.LookAt(playerEntity.transform);
            }
        }
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
