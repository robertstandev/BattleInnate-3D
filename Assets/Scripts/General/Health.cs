using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth = 100;

    public void addHealth(int value) { this.currentHealth = (this.currentHealth + value) <= 100 ? this.currentHealth + value : 100; }

    public void substractHealth(int value) { this.currentHealth = (this.currentHealth - value) >= 0 ? this.currentHealth - value : 0; }

    public int getCurrentHealth() { return this.currentHealth; }
}