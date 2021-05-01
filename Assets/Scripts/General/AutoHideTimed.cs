using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideTimed : MonoBehaviour
{
   [SerializeField]private float hideAfterNrOfSeconds = 10f;
    private Timer timerComponent;
    private int hideTimerInstance;

    private void Awake() { timerComponent = GetComponent<Timer>(); }

    private void OnEnable()
    {
        hideTimerInstance = timerComponent.createTimerInstanceAndGetIndex(false, hideAfterNrOfSeconds, hide);
        timerComponent.startTimer(hideTimerInstance);
    }

    private void OnDisable() { timerComponent.stopTimer(hideTimerInstance); }

    private void hide() { gameObject.SetActive(false); }
}
