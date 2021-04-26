using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private int currentStamina = 100;

    public void addStamina(int value) { this.currentStamina = (this.currentStamina + value) <= 100 ? this.currentStamina + value : 100; }

    public void substractStamina(int value) { this.currentStamina = (this.currentStamina - value) >= 0 ? this.currentStamina - value : 0; }

    public int getCurrentStamina() { return this.currentStamina; }
}
