using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFallenOffMap : MonoBehaviour, IOnTriggerAction
{
    private Vector3 startupPosition;
    private Quaternion startupRotation;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        startupPosition = transform.position;
        startupRotation = transform.rotation;
    }

    public void doAction()
    {
        respawn();
    }

    private void respawn()
    {
        changePositionAndRotation();
        resetRigidbody();
    }

    private void changePositionAndRotation() { transform.SetPositionAndRotation(startupPosition , startupRotation); }

    private void resetRigidbody()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
