using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatsModifier : MonoBehaviour , IOnTriggerAction
{
    [SerializeField]private int healthToAdd = 10;
    [SerializeField]private int massModifier = 2;
    [SerializeField]private int movementModifier = 20;

    public void activateTriggerEvent(GameObject player)
    {
        player.GetComponent<Health>()?.addHealth(healthToAdd);
        player.GetComponent<Rigidbody>().mass = (float) player.GetComponent<Health>()?.getCurrentHealth() * massModifier;
        player.GetComponent<Movement>()?.setMovementSpeed((float) player.GetComponent<Health>()?.getCurrentHealth() * movementModifier);
    }
}