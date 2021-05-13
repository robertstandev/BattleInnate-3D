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
       if(currentEnemyDeaths < enemyDeaths)
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
        canvasText.text = textString;
        canvasText.enabled = true;
        Invoke("returnToMainMenu", 2f);
   }

   private void freezeAllRigidbody()
   {
       rigidbodyContainingObjects = GameObject.FindObjectsOfType<Rigidbody>();

       for(int i = 0; i < rigidbodyContainingObjects.Length; i++)
       {
           rigidbodyContainingObjects[i].constraints = RigidbodyConstraints.FreezeAll;
       }
   }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}
