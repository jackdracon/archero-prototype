using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity's general information
/// </summary>
public abstract class Entity : MonoBehaviour, IEntity
{
    [SerializeField, Tooltip("Entity's life")]
    private float life;

    [SerializeField, Tooltip("Current state from object")]
    private STATE currentState;

    //Move from a start position to a target position
    public virtual void MoveTo(Vector3 _startPosition, Vector3 _targetDestination){}

    //Look to a specific direction when that get a object to look
    public virtual void LookTo(Vector3 _lookValue)
    {
        Vector3 _toLook = Vector3.RotateTowards(transform.forward, _lookValue, 5 * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(_toLook);
        Debug.Log("Rotate To - " + _toLook.ToString());
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