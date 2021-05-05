using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideTriggered : MonoBehaviour , IOnTriggerAction
{
    public void activateTriggerEvent(GameObject triggeredObject) { gameObject.SetActive(false); }
}