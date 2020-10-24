using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveCommand : Command
{
    //current direction to go
    private Vector3 targetPosition;
    
    //current position from object
    private Vector3 startPosition;
    //Construtor
    public MoveCommand(Vector3 _direction, IEntity _entity) : base(_entity)
    {
        targetPosition = _direction;
    }

    //Execute the action necessary
    public override void Execute()
    {
        ///moviment the object
        startPosition = entity.transform.position;
        entity.MoveTo(startPosition, targetPosition);
    }
}
