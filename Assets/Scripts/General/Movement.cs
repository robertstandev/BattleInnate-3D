using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField]private float movementSpeed = 10f;
    private Vector3 movementVector3 = Vector3.zero;
    private Rigidbody rb;

    private void Awake() { rb = GetComponent<Rigidbody>(); }

    private void FixedUpdate() { rb.AddForce(movementVector3 * movementSpeed); }

    public void moveCharacter(Vector2 movementVector2)
    {
        movementVector3.x = movementVector2.x;
        movementVector3.z = movementVector2.y;
    }
}
