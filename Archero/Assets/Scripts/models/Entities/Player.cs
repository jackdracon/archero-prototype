using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player's value 
/// </summary>
[RequireComponent(typeof(InputReader))]
public class Player : Entity
{

    private InputReader input;

    private void Awake()
    {
        input = GetComponent<InputReader>();        
    }

    // Update is called once per frame
    void Update()
    {
        var _position = input.GetClickPosition();
        if (_position != null)
        {
            Debug.Log("Pos Received " + _position.Value);
            this.transform.SetPositionAndRotation(_position.Value, Quaternion.identity);
        }
            
    }
}
