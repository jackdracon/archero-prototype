using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    ///current direction to go
    private Vector3 currDirection;

    //Construtor
    public MoveCommand(Vector3 _direction, IEntity _entity) : base(_entity)
    {
        currDirection = _direction;
    }

    //Execute the action necessary
    public override void Execute()
    {
        ///moviment the object 
        entity.transform.position = currDirection;
    }
}
