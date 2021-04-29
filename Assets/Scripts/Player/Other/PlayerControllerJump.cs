using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerJump : MonoBehaviour
{
    private InputAction jumpInput;
    private Jump jumpComponent;
    private Stamina staminaComponent;
    private CheckSurroundings checkSurroundingsComponent;
    private Rigidbody rb;
    private Renderer charRenderer;

    private void Awake()
    {
        jumpInput = GetComponent<IPlayerInput>().getJumpInput;
        jumpInput.performed += ctx => OnJump();

        jumpComponent = GetComponent<Jump>();
        staminaComponent = GetComponent<Stamina>();
        checkSurroundingsComponent = GetComponent<CheckSurroundings>();
        rb = GetComponent<Rigidbody>();
        charRenderer = GetComponent<Renderer>();
    }

    private void OnEnable() { jumpInput.Enable(); }
    private void OnDisable() { jumpInput.Disable(); }

    private void OnJump(){ jumpComponent.jump(rb, staminaComponent , 10); }

    private void LateUpdate()
    {
        if(checkSurroundingsComponent.isGrounded(charRenderer))
        {
            jumpComponent.setJumpCounter(1);
        }
    }
}
