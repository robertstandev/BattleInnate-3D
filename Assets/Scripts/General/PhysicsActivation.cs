using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsActivation : MonoBehaviour
{
    [SerializeField]private float activateGravityAfterSec = 3f;
    private Rigidbody rbComponent;
    private Timer timerComponent;
    private int activateGravityTimerInstance;

    private void Awake()
    { 
        timerComponent = GetComponent<Timer>();
        rbComponent = GetComponent<Rigidbody>();
    }
    
    private void OnEnable() { activateGravityTimerInstance = timerComponent.createTimerInstanceAndGetIndex(activateGravityAfterSec, activateGravity); }

    private void OnDisable() { timerComponent.stopTimer(activateGravityTimerInstance); }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timerComponent.startTimer(activateGravityTimerInstance);
        }
    }

    private void activateGravity(){
        rbComponent.isKinematic = false;
        rbComponent.useGravity = true;
    }
}