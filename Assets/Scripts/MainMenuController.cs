using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController: MonoBehaviour
{
    // ======================================
    // Main Menu Functions
    // ======================================
    public void OnPlayGameButtonClicked()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void OnExitButtonClicked()
    {
        if (Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
}
