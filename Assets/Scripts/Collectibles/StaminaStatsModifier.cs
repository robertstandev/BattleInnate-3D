using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaStatsModifier : MonoBehaviour , IOnTriggerAction
{
    [SerializeField]private int staminaToAdd = 50;
    
    public void activateTriggerEvent(GameObject player)
    {
        player.GetComponent<Stamina>()?.addStamina(this.staminaToAdd);
    }
}