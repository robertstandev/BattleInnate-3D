using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuTrigger : MonoBehaviour , IOnTriggerAction
{
    private Timer timerComponent;
    private int returnToMainMenuTimerInstance;

    private void Awake() { timerComponent = GetComponent<Timer>(); }
    
    public void doAction()
    { 
        returnToMainMenuTimerInstance = timerComponent.createTimerInstanceAndGetIndex(false, 3f, returnToMainMenu);
        timerComponent.startTimer(returnToMainMenuTimerInstance);
        
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Renderer>().enabled = false;
    }

    private void returnToMainMenu() { SceneManager.LoadSceneAsync(0, LoadSceneMode.Single); }
}