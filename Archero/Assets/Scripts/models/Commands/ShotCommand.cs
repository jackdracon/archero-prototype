using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCommand : Command
{
    //Target object to shot
    Transform targetObj;

    //Constructor
    public ShotCommand(IEntity _entity, Transform _target) : base(_entity)
    {
        targetObj = _target;
    }

    //Execute the shot command by passing the target object
    public override void Execute()
    {
        //entity.ShotTarget(targetObj);
        Debug.Log(entity.transform.gameObject.name + " @ Shoot on - " + targetObj.gameObject.name);
    }
}
