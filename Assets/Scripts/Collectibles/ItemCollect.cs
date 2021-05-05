using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<IOnTriggerAction>()?.activateTriggerEvent(other.gameObject);
        gameObject.SetActive(false);
    }
}