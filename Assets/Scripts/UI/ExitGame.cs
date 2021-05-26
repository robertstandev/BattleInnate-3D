using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitGame : MonoBehaviour , IPointerClickHandler
{
public void OnPointerClick(PointerEventData data) { Application.Quit(); }
}
