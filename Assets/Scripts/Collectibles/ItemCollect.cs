using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Health>() != null)
        {
            GetComponent<IStatsModifier>().modifyStats(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}