using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity's general information
/// </summary>
public abstract class Entity : MonoBehaviour
{
    [SerializeField, Tooltip("Entity's life")]
    private float life;

    [SerializeField, Tooltip("Entity's name")]
    private string name;

    [SerializeField, Tooltip("Current state from object")]
    private STATE currentState;

    //Look to a specific direction when that get a object to look
    public virtual void LookTo(Transform _lookValue)
    {
        this.transform.LookAt(_lookValue);
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