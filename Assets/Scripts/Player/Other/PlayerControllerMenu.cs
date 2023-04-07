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
        this.menuInput = GetComponent<IPlayerInput>().getMenuInput;
        this.menuInput.performed += ctx => OnMenuCalled();
    }
    private void OnEnable() { this.menuInput.Enable(); }
    private void OnDisable() { this.menuInput.Disable(); }
    private void OnMenuCalled() { this.menuCanvas.enabled = !this.menuCanvas.enabled; }
}