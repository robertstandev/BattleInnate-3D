using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour, IOnTriggerAction
{
    [SerializeField]private int nrOfTries = 3;
    [SerializeField]private Text textComponent;
    private RespawnPlayer respawnPlayerComponent;
    private ScoreManager scoreManagerComponent;
    private int counterTries = 0;

    private void Awake()
    { 
        respawnPlayerComponent = FindObjectOfType<RespawnPlayer>();
        scoreManagerComponent = GetComponent<ScoreManager>();
    }

    public void activateTriggerEvent(GameObject triggeredObject)
    {
        if(triggeredObject.CompareTag("Player"))
        {
            respawnPlayerComponent.stopRigidbody();
            Invoke("checkWhatToDo" , 5f);
        }
    }

    private void checkWhatToDo()
    {
        counterTries += 1;

        if(counterTries == nrOfTries || scoreManagerComponent.getScore() == 10)
        {
            createEndMessage();
            Invoke("returnToMainMenu", 3f);
        }
        else
        {
            respawnPlayerComponent.respawn();
        }
    }

    private void createEndMessage()
    {
        if(scoreManagerComponent.getScore() < 10)
        {
            textComponent.text = "You lost!";
        }
        else
        {
            textComponent.text = "You won!";
        }

        textComponent.enabled = true;
    }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}