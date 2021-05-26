using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnToMainMenu : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData data) { transform.GetComponent<ScenesManager>().returnToMainMenu(); }
}
