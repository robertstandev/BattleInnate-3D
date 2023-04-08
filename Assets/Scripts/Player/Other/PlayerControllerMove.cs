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
        this.movementInput = GetComponent<IPlayerInput>().getMovementInput;
        this.movementInput.performed += ctx => OnMove(ctx);
        this.movementInput.canceled += ctx => OnMove(ctx);

        this.movementComponent = GetComponent<Movement>();
        this.rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() { this.movementInput.Enable(); }
    private void OnDisable() { this.movementInput.Disable(); }

    private void FixedUpdate() { this.movementComponent.moveCharacter(this.rb); }

    private void OnMove(InputAction.CallbackContext context) { this.movementComponent.changeMovementData(context.ReadValue<Vector2>()); }
}