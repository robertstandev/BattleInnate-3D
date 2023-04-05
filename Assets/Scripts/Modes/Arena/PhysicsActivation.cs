using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsActivation : MonoBehaviour
{
    [SerializeField]private float activateGravityAfterSec = 2f;
    private Rigidbody rbComponent;

    private void Awake() { this.rbComponent = GetComponent<Rigidbody>(); }

    private void OnDisable() { CancelInvoke(); }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Invoke("activateGravity", this.activateGravityAfterSec);
        }
    }

    private void activateGravity()
    {
        this.rbComponent.isKinematic = false;
        this.rbComponent.useGravity = true;
    }
}