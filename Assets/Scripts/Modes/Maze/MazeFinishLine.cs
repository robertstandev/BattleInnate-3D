using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeFinishLine : MonoBehaviour, IOnTriggerAction
{
    [SerializeField]private Text textCanvas;
    public void activateTriggerEvent(GameObject triggeredObject)
    {
        triggeredObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        textCanvas.enabled = true;
        Invoke("returnToMainMenu", 3f);
    }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}