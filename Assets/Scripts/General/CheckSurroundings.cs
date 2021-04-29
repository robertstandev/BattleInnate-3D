using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSurroundings : MonoBehaviour
{
    private RaycastHit groundCheckBoxTrigger;
    private Vector3 groundCheckBoxPositionStart;
    private Vector3 groundCheckBoxSize = new Vector3(0f, 0.2f , 0f);

    public bool isGrounded(Renderer characterRenderer){
        groundCheckBoxSize.x = characterRenderer.bounds.size.x;
        groundCheckBoxSize.z = characterRenderer.bounds.size.z;

        groundCheckBoxPositionStart = transform.position;
        groundCheckBoxPositionStart.y -= characterRenderer.bounds.extents.y - 0.4f;
        
        return Physics.BoxCast(groundCheckBoxPositionStart, groundCheckBoxSize, Vector3.down, out groundCheckBoxTrigger,Quaternion.identity, groundCheckBoxSize.y);
    }
}
