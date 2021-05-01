using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IRespawn>() != null)
        {
            other.gameObject.GetComponent<IRespawn>().respawn();
        }
    }  
}