using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIArenaDelimiterPushBack : MonoBehaviour, IOnTriggerAction
{
    private Rigidbody rb;

    public void activateTriggerEvent(GameObject triggeredObject)
    {
        if (!triggeredObject.CompareTag("Enemy"))
        {
            return;
        }
        else
        {
            rb = triggeredObject.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }
}
