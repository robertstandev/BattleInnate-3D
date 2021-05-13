using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRace : MonoBehaviour
{
    private Movement movementComponent;
    private Jump jumpComponent;
    private Stamina staminaComponent;
    private CheckSurroundings groundDetectionComponent;

    private Rigidbody rb;
    private Renderer charRenderer;

    [SerializeField]private float distanceForObstacleCheck = 50f;
    private RaycastHit obstacleRaycastHit;
    private Vector3 obstaclePositionCheck;
    private Vector3 obstacleCheckBoxSize;

    private bool canMakeDecision = true;

    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
        jumpComponent = GetComponent<Jump>();
        staminaComponent = GetComponent<Stamina>();
        groundDetectionComponent = GetComponent<CheckSurroundings>();

        rb = GetComponent<Rigidbody>();
        charRenderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        if(canMakeDecision)
        {
            makeDecision();
        }

        movementComponent.moveCharacter(rb);
    }

    private void LateUpdate()
    {
        if(groundDetectionComponent.isGrounded(charRenderer))
        {
            jumpComponent.setJumpCounter(1);
            canMakeDecision = true;
        }
    }

    private bool isObjectDetected(Renderer objectRenderer, float raycastHeight , Vector3 boxCastDirection , float distanceToCheck)
    {
        obstacleCheckBoxSize.x = objectRenderer.bounds.extents.x;
        obstacleCheckBoxSize.y = objectRenderer.bounds.extents.y;
        obstacleCheckBoxSize.z = distanceToCheck;

        obstaclePositionCheck = transform.position;
        obstaclePositionCheck.y += raycastHeight;
        obstaclePositionCheck.z -= obstacleCheckBoxSize.z - objectRenderer.bounds.extents.z - 0.1f;

        return Physics.BoxCast(obstaclePositionCheck, obstacleCheckBoxSize, boxCastDirection, out obstacleRaycastHit, Quaternion.identity, obstacleCheckBoxSize.z);
    }

    private void makeDecision()
    {
        //Rewrite it cleaner

        if(isObjectDetected(charRenderer, 0f, Vector3.forward, distanceForObstacleCheck) && !isObjectDetected(charRenderer, 3f, Vector3.forward, distanceForObstacleCheck) && staminaComponent.getCurrentStamina() > 9)
        {//is small obstacle and has 10 stamina for jump
            jumpComponent.jump(rb, staminaComponent , 10);
            movementComponent.changeMovementData(new Vector2(0f, 1f));
        }
        else if(isObjectDetected(charRenderer, 3f, Vector3.forward, distanceForObstacleCheck) && !isObjectDetected(charRenderer, 6f, Vector3.forward, distanceForObstacleCheck) && staminaComponent.getCurrentStamina() > 19)
        {//is medium obstacle and has 20 stamina for 2 jumps
            jumpComponent.jump(rb, staminaComponent , 10);
            jumpComponent.jump(rb, staminaComponent , 10);
            movementComponent.changeMovementData(new Vector2(0f, 1f));
        }
        else if(isObjectDetected(charRenderer, 6f, Vector3.forward, distanceForObstacleCheck) || isObjectDetected(charRenderer, 0f, Vector3.forward, distanceForObstacleCheck) && staminaComponent.getCurrentStamina() < 10 || isObjectDetected(charRenderer, 3f, Vector3.forward, distanceForObstacleCheck) && staminaComponent.getCurrentStamina() < 20)
        {//is either high obstacle or small/medium obstacle and not enough stamina
            if(isObjectDetected(charRenderer, 0f, Vector3.left, 1f))
            {//is obstacle to the left
                movementComponent.changeMovementData(new Vector2(1f, 0.1f));
            }
            else if(isObjectDetected(charRenderer, 0f, Vector3.right, 1f))
            {//is obstacle to the right
                movementComponent.changeMovementData(new Vector2(-1f, 0.1f));
            }
            else
            {//no obstacle to the right or left but still is either high obstacle or small/medium obstacle in front and not enough stamina
                movementComponent.changeMovementData(new Vector2(0.1f, 0.1f));
            }
        }
        else
        {
            movementComponent.changeMovementData(new Vector2(0f, 1f));
        }

        canMakeDecision = false;
    }
}
