using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float movementSpeed = 10f;
    private Rigidbody rb;
    private Vector3 movementVector3 = Vector3.zero;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void moveCharacter(Vector2 movementVector2)
    {
        movementVector3.x = movementVector2.x;
        movementVector3.z = movementVector2.y;
    }

    private void FixedUpdate(){
        rb.AddForce(movementVector3 * movementSpeed);
    }
}