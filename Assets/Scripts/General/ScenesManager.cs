using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void loadScene(int sceneNumber) { SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Single); }

    public void returnToMainMenu() { loadScene(0); }
}