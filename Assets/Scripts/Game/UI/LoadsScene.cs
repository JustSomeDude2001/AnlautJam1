using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadsScene : MonoBehaviour
{
    public string scene;

    public void LoadScene() {
        GameState.NewGame();
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
