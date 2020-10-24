using UnityEngine;

//Interface focused to simplify access to the object
public interface IEntity
{
    //transform's value to access
    Transform transform { get; }
}
