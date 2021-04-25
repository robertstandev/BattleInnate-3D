using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float movementSpeed = 10f;
    
    public void moveCharacter(Rigidbody characterRigidbody, Vector2 movementVector2){
        characterRigidbody.AddForce(movementVector2 * movementSpeed);
    }
}
