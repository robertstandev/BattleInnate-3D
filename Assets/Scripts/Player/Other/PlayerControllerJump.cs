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
    private Rigidbody rb;

    private void Awake()
    {
        jumpInput = GetComponent<IPlayerInput>().getJumpInput;
        jumpInput.performed += ctx => OnJump();

        jumpComponent = GetComponent<Jump>();
        staminaComponent = GetComponent<Stamina>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() { jumpInput.Enable(); }
    private void OnDisable() { jumpInput.Disable(); }

    private void OnJump() { jumpComponent.jump(rb, staminaComponent , 10); }
}
