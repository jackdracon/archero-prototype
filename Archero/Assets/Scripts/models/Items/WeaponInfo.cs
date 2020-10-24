﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Weapon informations
[CreateAssetMenu(menuName ="Weapon/Info")]
public class WeaponInfo : ScriptableObject
{
    [SerializeField, Tooltip("Speed's fire")]
    private float speed;

    [SerializeField, Tooltip("time spent to recharge to fire")]
    private float rechargeVelocity;

    [SerializeField, Tooltip("Force's on fire shot")]
    private float fireForce;

    [SerializeField, Tooltip("Bullet's lifespan time")]
    private float bulletLifespan;

    //Speed's shot when fired
    public float GetSpeed
    {
        get { return speed; }
    }

    //Time spent to recharge the possibility
    public float GetRechargeVelocity
    {
        get { return rechargeVelocity; }
    }

    //bullet's force damage to be applied
    public float GetFireForce
    {
        get { return fireForce; }
    }
}