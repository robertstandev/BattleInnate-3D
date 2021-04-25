using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaStatsModifier : MonoBehaviour , IStatsModifier
{
    public void addToCharacter(GameObject player)
    {
        player.GetComponent<Stamina>()?.addStamina(50);
    }
}
