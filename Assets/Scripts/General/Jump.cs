using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField]private float jumpPower = 10f;
    [SerializeField]private int maxJumps = 2;
    private int jumpCounter = 0;
    private Vector3 jumpVector3 = new Vector3(0f, 100f, 0f);
    private Rigidbody rb;

    private void Awake() { rb = GetComponent<Rigidbody>(); }

    public void jump()
    {
        if(jumpCounter < maxJumps){
            jumpCounter += 1;
            rb.AddForce(jumpVector3 * jumpPower);
        }
    }
}
