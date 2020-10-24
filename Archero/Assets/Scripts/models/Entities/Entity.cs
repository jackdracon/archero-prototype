using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity's general information
/// </summary>
public abstract class Entity : MonoBehaviour, IEntity
{
    [Tooltip("Distance to player")]
    public float distance = 2f;

    [SerializeField, Tooltip("Entity's life")]
    private float life;

    [SerializeField, Tooltip("Current state from object")]
    private STATE currentState;

    //Flag to enable the shot command  action
    public bool canShoot = false;

    //Move from a start position to a target position
    public virtual void MoveTo(Vector3 _startPosition, Vector3 _targetDestination){}

    //Shot Target virtual object
    public virtual void ShotTarget(Transform _target) { }
    
    //Trigget the shot 
    private void OnTriggerEnter(Collider other)
    {
        //receive the shot
    }

    ///Damage received affected in life value
    public virtual void Damage(float _hit)
    {
        life -= _hit;
        if (life < 0) life = 0;
    }

    ///If the object's life is 0, it's dead;
    public bool IsDead { get { return life == 0 ? true : false; } }

    //Current state from object
    public STATE CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }
}

//States that is possible to assign to the object
public enum STATE
{
    STANDING,
    WALKING,
    SHOOTING
}