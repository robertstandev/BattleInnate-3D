using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{   
    private Movement movementComponent;
    private Jump jumpComponent;
    private Stamina staminaComponent;
    private Health healthComponent;

    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
        jumpComponent = GetComponent<Jump>();
        staminaComponent = GetComponent<Stamina>();
        healthComponent = GetComponent<Health>();
    }

    private void OnMove(InputValue movementValue) { movementComponent.moveCharacter(movementValue.Get<Vector2>()); }
    
    private void OnJump() { jumpComponent.jump(staminaComponent , 10); }

    private void OnFire(){ Debug.Log("Fired!"); }
}
