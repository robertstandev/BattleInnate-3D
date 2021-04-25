using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatsModifier : MonoBehaviour , IStatsModifier
{
    public void addToCharacter(GameObject player)
    {
        player.GetComponent<Health>()?.addHealth(25);
    }
}
