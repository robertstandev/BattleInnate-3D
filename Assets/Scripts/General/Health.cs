using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 100;

    public void addHealth(int value)
    {
        currentHealth = (currentHealth + value) <= 100 ? currentHealth + value : 100;
    }
}
