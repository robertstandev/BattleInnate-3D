using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen : MonoBehaviour, IOnTriggerAction
{
    public void activateTriggerEvent(GameObject triggeredObject)
    {
        triggeredObject.GetComponent<IFallenOffMap>()?.doFallenAction();
    }
}