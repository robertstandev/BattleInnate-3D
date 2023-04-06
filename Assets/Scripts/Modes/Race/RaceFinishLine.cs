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
        this.place += 1;
        if(triggeredObject.CompareTag("Player"))
        {
            configurePlaceDisplay();
            Invoke("returnToMainMenu", 3f);
        }
    }

    private void configurePlaceDisplay()
    {
        this.textComponent.text = "You finished : " + this.place;
        switch (this.place)
        {
            case 1:
                this.textComponent.text += "st";
                break;
            case 2:
                this.textComponent.text += "nd";
                break;
            case 3:
                this.textComponent.text += "rd";
                break;
        }
        this.textComponent.enabled = true;
    }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}