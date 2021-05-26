using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCPlayerInput : MonoBehaviour, IPlayerInput
 {
    [SerializeField]private InputAction movementInput;
    [SerializeField]private InputAction jumpInput;
    [SerializeField]private InputAction menuInput;

    public InputAction getMovementInput { get { return this.movementInput; } }
    public InputAction getJumpInput { get { return this.jumpInput; } }
    public InputAction getMenuInput { get { return this.menuInput; } }
}