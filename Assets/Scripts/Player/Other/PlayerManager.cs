using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{   
    private Movement movementComponent;
    private Jump jumpComponent;

    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
        jumpComponent = GetComponent<Jump>();
    }

    private void OnMove(InputValue movementValue) { movementComponent.moveCharacter(movementValue.Get<Vector2>()); }
    
    private void OnJump() { jumpComponent.jump(); }

    private void OnFire(){ Debug.Log("Fired!"); }
}
