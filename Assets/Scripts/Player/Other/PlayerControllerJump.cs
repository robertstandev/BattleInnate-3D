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
        this.jumpInput = GetComponent<IPlayerInput>().getJumpInput;
        this.jumpInput.performed += ctx => OnJump();

        this.jumpComponent = GetComponent<Jump>();
        this.staminaComponent = GetComponent<Stamina>();
        this.checkSurroundingsComponent = GetComponent<CheckSurroundings>();
        this.rb = GetComponent<Rigidbody>();
        this.charRenderer = GetComponent<Renderer>();
    }

    private void OnEnable() { this.jumpInput.Enable(); }
    private void OnDisable() { this.jumpInput.Disable(); }

    private void OnJump(){ this.jumpComponent.jump(this.rb, this.staminaComponent , 10); }

    private void LateUpdate()
    {
        if(this.checkSurroundingsComponent.isColliding(new Vector3(0f,-0.1f,0f), this.charRenderer, 0.2f, Vector3.down))
        {
            jumpComponent.setJumpCounter(1);
        }
    }
}