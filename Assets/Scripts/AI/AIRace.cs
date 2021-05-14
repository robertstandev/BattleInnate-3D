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

    [SerializeField]private float frontObstacleDistanceCheck = 65f;
    [SerializeField]private float sideObstacleDistanceCheck = 1f;
    private RaycastHit obstacleRaycastHit;
    private Vector3 obstaclePositionCheck;
    private Vector3 obstacleCheckBoxSize;

    private Vector2 movementData;
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
            checkFrontCollision();
            movementComponent.changeMovementData(movementData);
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
        obstaclePositionCheck.z -= obstacleCheckBoxSize.z - objectRenderer.bounds.extents.z - 0.3f;

        return Physics.BoxCast(obstaclePositionCheck, obstacleCheckBoxSize, boxCastDirection, out obstacleRaycastHit, Quaternion.identity, obstacleCheckBoxSize.z);
    }

    private void checkFrontCollision()
    {
        movementData = Vector2.zero;

        if(isObjectDetected(charRenderer, 1f, Vector3.forward, frontObstacleDistanceCheck) && !isObjectDetected(charRenderer, 3f, Vector3.forward, frontObstacleDistanceCheck) && staminaComponent.getCurrentStamina() > 9)
        {
            jumpComponent.jump(rb, staminaComponent , 10);
            movementData.y = 1f;
            canMakeDecision = false;
        }
        else if(isObjectDetected(charRenderer, 3f, Vector3.forward, frontObstacleDistanceCheck) && !isObjectDetected(charRenderer, 6f, Vector3.forward, frontObstacleDistanceCheck) && staminaComponent.getCurrentStamina() > 19)
        {
            jumpComponent.jump(rb, staminaComponent , 10);
            jumpComponent.jump(rb, staminaComponent , 10);
            movementData.y = 1f;
            canMakeDecision = false;
        }
        else if(isObjectDetected(charRenderer, 6f, Vector3.forward, frontObstacleDistanceCheck) || isObjectDetected(charRenderer, 1f, Vector3.forward, frontObstacleDistanceCheck) && staminaComponent.getCurrentStamina() < 10 || isObjectDetected(charRenderer, 3f, Vector3.forward, frontObstacleDistanceCheck) && staminaComponent.getCurrentStamina() < 20)
        {
           checkLateralCollision();
        }
        else
        {
            movementData.y = 1f;
        }
    }

    private void checkLateralCollision()
    {
         if(isObjectDetected(charRenderer, 1f, Vector3.left, sideObstacleDistanceCheck))
        {
            movementData.x = 1f;
        }
        else if(isObjectDetected(charRenderer, 1f, Vector3.right, sideObstacleDistanceCheck))
        {
            movementData.x = -1f;
        }
        else
        {
            movementData.x = 1f;
        }
        movementData.y = 1f;
    }
}
