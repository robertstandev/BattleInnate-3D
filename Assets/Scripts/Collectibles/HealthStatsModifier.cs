using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatsModifier : MonoBehaviour , IOnTriggerAction
{
    [SerializeField]private int healthToAdd = 25;

    public void activateTriggerEvent(GameObject player)
    {
        player.GetComponent<Health>()?.addHealth(healthToAdd);
    }
}