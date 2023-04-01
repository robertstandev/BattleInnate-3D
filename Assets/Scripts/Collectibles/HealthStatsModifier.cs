using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatsModifier : MonoBehaviour , IOnTriggerAction
{
    [SerializeField]private int healthToAdd = 10;
    [SerializeField]private int massModifier = 20;
    [SerializeField]private int movementModifier = 200;
    [SerializeField]private int jumpModifier = 90;

    public void activateTriggerEvent(GameObject player)
    {
        player.GetComponent<Health>()?.addHealth(this.healthToAdd);
        player.GetComponent<Rigidbody>().mass += this.massModifier;
        player.GetComponent<Movement>()?.setMovementSpeed(player.GetComponent<Movement>().getMovementSpeed() + this.movementModifier);
        player.GetComponent<Jump>()?.setJumpPower(player.GetComponent<Jump>().getJumpPower() + this.jumpModifier);
    }
}