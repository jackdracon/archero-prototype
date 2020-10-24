using UnityEngine;

//Interface focused to simplify access to the object
public interface IEntity
{
    //transform's value to access
    Transform transform { get; }

    //Move from a position to a target position
    void MoveTo(Vector3 _from, Vector3 _target);

    //Shot on the target direction
    void ShotTarget(Transform _target);
}