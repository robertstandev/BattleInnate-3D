using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceFinishLine : MonoBehaviour, IOnTriggerAction
{
    [SerializeField]private Text textComponent;
    private int place = 0;

    public void activateTriggerEvent(GameObject triggeredObject)
    {
        triggeredObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        place += 1;
        if(triggeredObject.CompareTag("Player"))
        {
            configurePlaceDisplay();
            Invoke("returnToMainMenu", 3f);
        }
    }

    private void configurePlaceDisplay()
    {
        textComponent.text = "You finished : " + place;
        switch (place)
        {
            case 1:
                textComponent.text += "st";
                break;
            case 2:
                textComponent.text += "nd";
                break;
            case 3:
                textComponent.text += "rd";
                break;
        }
        textComponent.enabled = true;
    }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}