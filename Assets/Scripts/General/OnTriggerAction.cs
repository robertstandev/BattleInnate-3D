using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IOnTriggerAction>() != null)
        {
            other.gameObject.GetComponent<IOnTriggerAction>().doAction();
        }
    }  
}