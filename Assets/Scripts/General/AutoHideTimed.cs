using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideTimed : MonoBehaviour
{
   [SerializeField]private float hideAfterNrOfSeconds = 10f;

    private void OnEnable() { Invoke("hide", hideAfterNrOfSeconds); }

    private void OnDisable() { CancelInvoke(); }

    private void hide() { gameObject.SetActive(false); }
}