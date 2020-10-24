using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Command object related to apply actions
public abstract class Command
{
    //entity to apply the command method
    protected IEntity entity;

    //Constructor
    public Command(IEntity _entity)
    {
        entity = _entity;
    }

    ///Apply the updates related to the related command into the object
    public virtual void Execute() { }
}
