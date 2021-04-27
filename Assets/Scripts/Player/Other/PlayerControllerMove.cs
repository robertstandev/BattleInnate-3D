using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
public class PlayerControllerMove : MonoBehaviour
{   
    private InputAction movementInput;
    private Movement movementComponent;

    private void Awake()
    {
        movementInput = GetComponent<IPlayerInput>().getMovementInput;
        movementInput.performed += ctx => OnMove(ctx);
        movementInput.canceled += ctx => OnMove(ctx);

        movementComponent = GetComponent<Movement>();
    }

    private void OnEnable()
    { 
        movementInput.Enable(); 
        movementComponent.enabled = true;
    }
    private void OnDisable() 
    { 
        movementInput.Disable();
        movementComponent.enabled = false;
    }

    private void OnMove(InputAction.CallbackContext context) { movementComponent.moveCharacter(context.ReadValue<Vector2>()); }
}
