using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMapModifier : MonoBehaviour
{
    [SerializeField]private Transform ground;
    [SerializeField]private Vector3 shrinkGroundPerTick = new Vector3(0.1f, 0.1f, 0f);
    private Timer timerComponent;
    private int mapModifierTimerInstance;

    private void Awake() { timerComponent = GetComponent<Timer>(); }

    private void OnEnable()
    { 
        mapModifierTimerInstance = timerComponent.createTimerInstanceAndGetIndex(true, 0.5f, scaleMap);
        timerComponent.startTimer(mapModifierTimerInstance);
    }

    private void OnDisable() { timerComponent.stopTimer(mapModifierTimerInstance); }

    private void scaleMap()
    {
        if(ground.localScale.x < 10f || ground.localScale.y < 10f)
        {
            timerComponent.stopTimer(mapModifierTimerInstance);
        }
        else
        {
            ground.localScale -= shrinkGroundPerTick;
        } 
    }
}
