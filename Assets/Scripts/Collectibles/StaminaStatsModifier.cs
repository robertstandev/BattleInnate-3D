using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaStatsModifier : MonoBehaviour , IStatsModifier
{
    [SerializeField]private int staminaToAdd = 50;
    public void addToCharacter(GameObject player)
    {
        player.GetComponent<Stamina>()?.addStamina(staminaToAdd);
    }
}
