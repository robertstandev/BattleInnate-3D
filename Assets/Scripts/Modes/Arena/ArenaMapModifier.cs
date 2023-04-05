using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMapModifier : MonoBehaviour
{
    [SerializeField]private Transform ground;
    [SerializeField]private Vector3 shrinkGroundPerTick = new Vector3(0.1f, 0.1f, 0f);

    private void OnEnable() { InvokeRepeating("scaleMap", 0f, 0.5f); }

    private void OnDisable() { CancelInvoke(); }

    private void scaleMap()
    {
        if(this.ground.localScale.x < 10f || this.ground.localScale.y < 10f)
        {
            CancelInvoke();
        }
        else
        {
            this.ground.localScale -= this.shrinkGroundPerTick;
        } 
    }
}