using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour , IRespawn
{
    [SerializeField]private Vector3 position;
    [SerializeField]private Quaternion rotation;
    private Rigidbody rb;
    private PlayerControllerMove controllerMoveComponent;
    private PlayerControllerJump controllerJumpComponent;

    private void Awake()
    { 
        rb = GetComponent<Rigidbody>();
        controllerMoveComponent = GetComponent<PlayerControllerMove>();
        controllerJumpComponent = GetComponent<PlayerControllerJump>();
    }

    public void respawn()
    {
        resetComponents();
        changePositionAndRotation();
    }

    private void changePositionAndRotation() { transform.SetPositionAndRotation(position , rotation); }

    private void resetComponents()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if(controllerMoveComponent != null)
        {
            controllerMoveComponent.enabled = true;
        }
        
        if(controllerJumpComponent != null)
        {
            controllerJumpComponent.enabled = true;
        }

    }
}