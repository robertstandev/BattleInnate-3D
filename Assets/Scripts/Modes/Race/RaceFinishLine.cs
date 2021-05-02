using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceFinishLine : MonoBehaviour, IOnTriggerAction
{
    [SerializeField]private Text textComponent;
    private int place = 0;

    public void doAction()
    {
        place += 1;
        textComponent.text = "Units Finished : " + place;
        textComponent.enabled = true;
    }
}
