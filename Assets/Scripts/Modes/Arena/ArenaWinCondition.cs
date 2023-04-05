using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaWinCondition : MonoBehaviour, IOnTriggerAction
{
   [SerializeField]int enemyDeaths = 10;
   [SerializeField]Text canvasText;
   private int currentEnemyDeaths = 1;
   private Rigidbody[] rigidbodyContainingObjects;

   public void activateTriggerEvent(GameObject trigger)
   {
       if(trigger.CompareTag("Enemy"))
       {
           checkWinCondition();
       }
       if(trigger.CompareTag("Player"))
       {
           gameEnded("You lost!");
       }
   }

   private void checkWinCondition()
   {
       if(this.currentEnemyDeaths < this.enemyDeaths)
        {
            this.currentEnemyDeaths += 1;
        }
        else
        {
            gameEnded("You won!");
        }
   }

   private void gameEnded(string textString)
   {
       freezeAllRigidbody();
        this.canvasText.text = textString;
        this.canvasText.enabled = true;
        Invoke("returnToMainMenu", 2f);
   }

   private void freezeAllRigidbody()
   {
       this.rigidbodyContainingObjects = GameObject.FindObjectsOfType<Rigidbody>();

       for(int i = 0; i < this.rigidbodyContainingObjects.Length; i++)
       {
           this.rigidbodyContainingObjects[i].constraints = RigidbodyConstraints.FreezeAll;
       }
   }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}
