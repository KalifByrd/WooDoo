using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementManager : MonoBehaviour
{
    [SerializeField]
    private Camera screenCamera;
    private Vector3 lastPosition;

    [SerializeField]
    private LayerMask placementLayermask;
    
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = screenCamera.nearClipPlane;
        Ray ray = screenCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, placementLayermask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }
}
