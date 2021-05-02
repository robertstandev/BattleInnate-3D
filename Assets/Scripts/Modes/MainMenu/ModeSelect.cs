using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModeSelect : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]private int sceneNumber = 0;
    private ScenesManager scenesManager;

    private void Awake() { scenesManager = transform.parent.GetComponent<ScenesManager>(); }

    public void OnPointerDown(PointerEventData eventData) { scenesManager.loadScene(sceneNumber); }
}