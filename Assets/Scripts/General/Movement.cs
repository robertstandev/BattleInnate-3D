using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float movementSpeed = 10f;
    private Vector3 movementVector3 = Vector3.zero;

    public void changeMovementData(Vector2 movementVector2)
    {
        movementVector3.x = movementVector2.x;
        movementVector3.z = movementVector2.y;
    }

    public void moveCharacter(Rigidbody rb){ rb.AddForce(movementVector3 * movementSpeed); }

    public void setMovementSpeed(float value) { this.movementSpeed = value; }

    public float getMovementSpeed() { return this.movementSpeed; }
}