using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Input Reader that monitoring input receives
public class InputReader : MonoBehaviour
{
    [Tooltip("Default height to apply on input")]
    private float heightToFloor = -0.784f;
    //Return the value that contain a vector3 value or null for not ray value founded
    public Vector3? MoveInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                Vector3 _pos = new Vector3(_hit.point.x, heightToFloor, _hit.point.z);

                return _pos;
            }
        }

        return null;
    }

}
