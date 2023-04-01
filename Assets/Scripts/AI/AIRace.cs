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
        this.movementComponent = GetComponent<Movement>();
        this.jumpComponent = GetComponent<Jump>();
        this.staminaComponent = GetComponent<Stamina>();
        this.checkSurroundingsComponent = GetComponent<CheckSurroundings>();

        this.rb = GetComponent<Rigidbody>();
        this.charRenderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        checkFrontCollision();
        checkSideCollision();
        this.movementComponent.changeMovementData(this.movementData);
        this.movementComponent.moveCharacter(this.rb);
    }

    private void LateUpdate()
    {
        if(this.checkSurroundingsComponent.isColliding(new Vector3(0f,-0.1f,0f), this.charRenderer, 0.2f, Vector3.down))
        {
            this.jumpComponent.setJumpCounter(1);
        }
    }

    private void checkFrontCollision()
    {
        if(this.checkSurroundingsComponent.isColliding(new Vector3(0f,0f, -1* this.frontObstacleDistanceCheck), this.charRenderer, this.frontObstacleDistanceCheck, Vector3.forward) && this.staminaComponent.getCurrentStamina() >= 10)
        {
            this.jumpComponent.jump(this.rb, this.staminaComponent , 5);
        }
        this.movementData.y = 1f;
    }

    private void checkSideCollision()
    {
        this.movementData.x = 0f;
        if(this.checkSurroundingsComponent.isColliding(new Vector3(0.6f,0f, -0.1f), this.charRenderer, 1f, Vector3.left))
        {
            this.movementData.x = 1f;
        }
        else if(this.checkSurroundingsComponent.isColliding(new Vector3(-0.6f,0f, - 0.1f), this.charRenderer, 1f, Vector3.right))
        {
            this.movementData.x = -1f;
        }
        else
        {
            if(this.checkSurroundingsComponent.isColliding(new Vector3(0f,0f, 0.2f), this.charRenderer, 0.2f, Vector3.forward))
            {
                this.movementData.x = 1f;
            }
        }
    }
}