using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerMove : MonoBehaviour
{   
    private InputAction movementInput;

    private Movement movementComponent;
    private Rigidbody rb;

    private void Awake()
    {
        movementInput = GetComponent<IPlayerInput>().getMovementInput;
        movementInput.performed += ctx => OnMove(ctx);
        movementInput.canceled += ctx => OnMove(ctx);

        movementComponent = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() { movementInput.Enable(); }
    private void OnDisable() { movementInput.Disable(); }

    private void FixedUpdate() { movementComponent.moveCharacter(rb); }

    private void OnMove(InputAction.CallbackContext context) { movementComponent.changeMovementData(context.ReadValue<Vector2>()); }
}