using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerMenu : MonoBehaviour
{
    [SerializeField]private Canvas menuCanvas;
    private InputAction menuInput;
    private void Awake()
    {
        menuInput = GetComponent<IPlayerInput>().getMenuInput;
        menuInput.performed += ctx => OnMenuCalled();
    }
    private void OnEnable() { menuInput.Enable(); }
    private void OnDisable() { menuInput.Disable(); }
    private void OnMenuCalled() { menuCanvas.enabled = !menuCanvas.enabled; }
}