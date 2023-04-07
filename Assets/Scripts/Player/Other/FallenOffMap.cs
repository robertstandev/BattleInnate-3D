using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallenOffMap : MonoBehaviour , IFallenOffMap
{
    [SerializeField]private Text textComponent;

    public void doFallenAction()
    { 
        Invoke("returnToMainMenu", 3f);
        
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Renderer>().enabled = false;

        this.textComponent.text = "You lost!";
        this.textComponent.enabled = true;
    }

    private void returnToMainMenu() { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}