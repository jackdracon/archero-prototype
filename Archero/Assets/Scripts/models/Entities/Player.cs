using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player's value 
/// </summary>
[RequireComponent(typeof(InputReader))]
public class Player : Entity
{
    //Input Reader values
    private InputReader input;

    //Apply the moviment updates to the object
    private MoveCommand moveCommand;
    private void Awake()
    {
        input = GetComponent<InputReader>();        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Move object
    void Move()
    {
        var _position = input.MoveInput();
        if (_position != null)
        {
            Debug.Log("Pos Received " + _position.Value);
            var _move = new MoveCommand(_position.Value, this);
            _move.Execute();
        }
    }

}
