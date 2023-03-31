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
            this.rb = triggeredObject.GetComponent<Rigidbody>();
            this.rb.angularVelocity = Vector3.zero;
            this.rb.velocity = Vector3.zero;
        }
    }
}
