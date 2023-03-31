using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFallenOffMap : MonoBehaviour, IFallenOffMap
{
    private Vector3 startupPosition;
    private Quaternion startupRotation;
    private Rigidbody rb;

    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
        this.startupPosition = transform.position;
        this.startupRotation = transform.rotation;
    }

    public void doFallenAction() { respawn(); }

    private void respawn()
    {
        changePositionAndRotation();
        resetRigidbody();
    }

    private void changePositionAndRotation() { transform.SetPositionAndRotation(this.startupPosition , this.startupRotation); }

    private void resetRigidbody()
    {
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
    }
}
