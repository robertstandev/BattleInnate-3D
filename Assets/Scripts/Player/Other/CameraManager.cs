using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private Vector3 cameraOffset;

    private void Start() { this.cameraOffset = transform.position - this.player.transform.position; }

    private void LateUpdate() { transform.position = this.player.transform.position + this.cameraOffset; }
}