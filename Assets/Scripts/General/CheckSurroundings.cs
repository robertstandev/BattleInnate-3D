using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSurroundings : MonoBehaviour
{
    private RaycastHit boxCastRaycastHit;
    private Vector3 boxCastPositionCheck;
    private Vector3 boxCastCheckBoxSize;

    public bool isColliding(Vector3 boxCastPositionOvverider, Renderer objectRenderer, float distanceCheck, Vector3 boxCastDirection)
    {
        boxCastPositionCheck = transform.position + boxCastPositionOvverider;
        boxCastCheckBoxSize = objectRenderer.bounds.extents;

        boxCastCheckBoxBuilder(boxCastDirection, distanceCheck);

        return Physics.BoxCast(boxCastPositionCheck, boxCastCheckBoxSize, boxCastDirection, out boxCastRaycastHit, Quaternion.identity, distanceCheck);
    }

    private void boxCastCheckBoxBuilder(Vector3 boxCastDirection, float distanceCheck)
    {
        if(boxCastDirection == Vector3.left || boxCastDirection == Vector3.right)
        {
             boxCastCheckBoxSize.x = distanceCheck;
        }
        else if(boxCastDirection == Vector3.down || boxCastDirection == Vector3.up)
        {
            boxCastCheckBoxSize.y = distanceCheck;
        }
        else
        {
            boxCastCheckBoxSize.z = distanceCheck;
        }
    }
}