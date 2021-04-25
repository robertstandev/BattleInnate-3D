using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{   
    private Movement movementComponent;

    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
    }

    private void OnMove(InputValue movementValue)
    {
        movementComponent.moveCharacter(movementValue.Get<Vector2>());
    }
}