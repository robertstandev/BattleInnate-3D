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
        this.respawnPlayerComponent = FindObjectOfType<RespawnPlayer>();
        this.scoreManagerComponent = GetComponent<ScoreManager>();
    }

    public void activateTriggerEvent(GameObject triggeredObject)
    {
        if(triggeredObject.CompareTag("Player"))
        {
            this.respawnPlayerComponent.stopRigidbody();
            Invoke("checkWhatToDo" , 5f);
        }
    }

    private void checkWhatToDo()
    {
        this.counterTries += 1;

        if(this.counterTries == this.nrOfTries || this.scoreManagerComponent.getScore() == 10)
        {
            createEndMessage();
            Invoke("returnToMainMenu", 3f);
        }
        else
        {
            this.respawnPlayerComponent.respawn();
        }
    }

    private void createEndMessage()
    {
        if(this.scoreManagerComponent.getScore() < 10)
        {
            this.textComponent.text = "You lost!";
        }
        else
        {
            this.textComponent.text = "You won!";
        }

        this.textComponent.enabled = true;
    }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}