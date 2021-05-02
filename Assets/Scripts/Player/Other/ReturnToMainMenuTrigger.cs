using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuTrigger : MonoBehaviour , IOnTriggerAction
{   
    public void doAction()
    { 
        Invoke("returnToMainMenu", 3f);
        
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Renderer>().enabled = false;
    }

    private void returnToMainMenu() { SceneManager.LoadSceneAsync(0, LoadSceneMode.Single); }
}