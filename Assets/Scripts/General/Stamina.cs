using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private int currentStamina = 100;

    public void addStamina(int value)
    {
        currentStamina = (currentStamina + value) <= 100 ? currentStamina + value : 100;
    }
}
