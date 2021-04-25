using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{   
    [SerializeField]private Movement movementComponent;
    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
    }

  private void FixedUpdate() {
      
  }

}
