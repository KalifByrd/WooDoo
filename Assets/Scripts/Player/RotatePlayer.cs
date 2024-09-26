using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    Vector3 previousPosition = Vector3.zero;
    Vector3 deltaPosition = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            deltaPosition = Input.mousePosition - previousPosition;
            transform.Rotate(transform.up, Vector3.Dot(deltaPosition, Camera.main.transform.right), Space.World);
        }
        previousPosition = Input.mousePosition;
    }
}
