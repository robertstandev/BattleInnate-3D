using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRace : MonoBehaviour
{
    private Movement movementComponent;
    private Jump jumpComponent;
    private Stamina staminaComponent;
    private CheckSurroundings checkSurroundingsComponent;

    private Rigidbody rb;
    private Renderer charRenderer;

    [SerializeField]private float frontObstacleDistanceCheck = 65f;

    private Vector2 movementData;

    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
        jumpComponent = GetComponent<Jump>();
        staminaComponent = GetComponent<Stamina>();
        checkSurroundingsComponent = GetComponent<CheckSurroundings>();

        rb = GetComponent<Rigidbody>();
        charRenderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        checkFrontCollision();
        checkSideCollision();
        movementComponent.changeMovementData(movementData);
        movementComponent.moveCharacter(rb);
    }

    private void LateUpdate()
    {
        if(checkSurroundingsComponent.isColliding(new Vector3(0f,-0.1f,0f), charRenderer, 0.2f, Vector3.down))
        {
            jumpComponent.setJumpCounter(1);
        }
    }

    private void checkFrontCollision()
    {
        if(checkSurroundingsComponent.isColliding(new Vector3(0f,0f, -1* frontObstacleDistanceCheck), charRenderer, frontObstacleDistanceCheck, Vector3.forward) && staminaComponent.getCurrentStamina() >= 10)
        {
            jumpComponent.jump(rb, staminaComponent , 5);
        }
        movementData.y = 1f;
    }

    private void checkSideCollision()
    {
        movementData.x = 0f;
        if(checkSurroundingsComponent.isColliding(new Vector3(0.6f,0f, -0.1f), charRenderer, 1f, Vector3.left))
        {
            movementData.x = 1f;
        }
        else if(checkSurroundingsComponent.isColliding(new Vector3(-0.6f,0f, - 0.1f), charRenderer, 1f, Vector3.right))
        {
            movementData.x = -1f;
        }
        else
        {
            if(checkSurroundingsComponent.isColliding(new Vector3(0f,0f, 0.2f), charRenderer, 0.2f, Vector3.forward))
            {
                movementData.x = 1f;
            }
        }
    }
}