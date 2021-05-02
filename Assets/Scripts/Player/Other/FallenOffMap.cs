using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FallenOffMap : MonoBehaviour , IOnTriggerAction
{
    [SerializeField]private Text textComponent;

    public void doAction()
    { 
        Invoke("returnToMainMenu", 3f);
        
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Renderer>().enabled = false;

        textComponent.text = "You lost!";
        textComponent.enabled = true;
    }

    private void returnToMainMenu() { SceneManager.LoadSceneAsync(0, LoadSceneMode.Single); }
}