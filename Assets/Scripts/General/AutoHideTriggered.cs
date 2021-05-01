using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideTriggered : MonoBehaviour , IOnTriggerAction
{
    public void doAction() { gameObject.SetActive(false); }
}