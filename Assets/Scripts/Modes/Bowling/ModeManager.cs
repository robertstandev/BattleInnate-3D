using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModeManager : MonoBehaviour, IOnTriggerAction
{
    [SerializeField]private int nrOfTries = 3;
    [SerializeField]private Text textComponent;
    private int counterTries = 0;

    public void doAction()
    {
        counterTries += 1;
        if(counterTries == nrOfTries)
        {
            textComponent.enabled = true;
            Invoke("returnToMainMenu", 1f);
        }
    }

    private void returnToMainMenu()
    {
        transform.GetComponent<ScenesManager>().loadScene(0);
    }
}