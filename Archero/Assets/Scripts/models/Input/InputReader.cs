using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Input Reader that monitoring input receives
public class InputReader : MonoBehaviour
{

    //Return the value that contain a vector3 value or null for not ray value founded
    public Vector3? MoveInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                return _hit.point;
            }
        }

        return null;
    }

    //Return when the Backspace is released than is possible 
    public bool ShotInput()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
            return true;
        return false;
    }

}
