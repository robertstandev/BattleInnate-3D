using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]private float jumpPower = 10f;
    [SerializeField]private int maxJumps = 2;
    private int jumpCounter = 0;
    private Vector3 jumpVector3 = new Vector3(0f, 100f, 0f);

    public void jump(Rigidbody rb, Stamina staminaComponent, int staminaToConsume)
    {
        if((jumpCounter < maxJumps) && (staminaComponent.getCurrentStamina() >= staminaToConsume))
        {
            staminaComponent.substractStamina(staminaToConsume);
            jumpCounter += 1;
            rb.AddForce(jumpVector3 * jumpPower);
        }
    }

    public void setJumpCounter(int value) { this.jumpCounter = value < maxJumps ? value : this.jumpCounter; }

    public int getJumpCounter() { return this.jumpCounter; }
}