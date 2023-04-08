using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField]private Vector3 position;
    [SerializeField]private Quaternion rotation;
    private Rigidbody rb;
    private PlayerControllerMove controllerMoveComponent;
    private PlayerControllerJump controllerJumpComponent;

    private void Awake()
    { 
        this.rb = GetComponent<Rigidbody>();
        this.controllerMoveComponent = GetComponent<PlayerControllerMove>();
        this.controllerJumpComponent = GetComponent<PlayerControllerJump>();
    }

    public void respawn()
    {
        resetComponents();
        changePositionAndRotation();
    }

    private void changePositionAndRotation() { transform.SetPositionAndRotation(this.position , this.rotation); }

    public void stopRigidbody() { this.rb.constraints = RigidbodyConstraints.FreezeAll; }

    private void resetComponents()
    {
        if(this.controllerMoveComponent != null)
        {
            this.controllerMoveComponent.enabled = true;
        }
        
        if(this.controllerJumpComponent != null)
        {
            this.controllerJumpComponent.enabled = true;
        }
        this.rb.constraints = RigidbodyConstraints.None;
    }
}