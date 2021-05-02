using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeFinishLine : MonoBehaviour, IOnTriggerAction
{
    [SerializeField]private Text textCanvas;
    public void doAction()
    {
        textCanvas.enabled = true;
    }
}
