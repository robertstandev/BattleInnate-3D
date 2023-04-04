using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAction : MonoBehaviour
{
    private IOnTriggerAction[] onTriggerActionScripts;

    private void Awake() { this.onTriggerActionScripts = GetComponents<IOnTriggerAction>(); }

    private void OnTriggerEnter(Collider other) { sendTriggeredObjectToScripts(other.gameObject); }

    private void sendTriggeredObjectToScripts(GameObject triggeredObject)
    {
        for(int i = 0; i < this.onTriggerActionScripts.Length; i++)
        {
            this.onTriggerActionScripts[i]?.activateTriggerEvent(triggeredObject);
        }
    }
}