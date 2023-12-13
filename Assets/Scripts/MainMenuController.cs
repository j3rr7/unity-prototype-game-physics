using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ======================================
    // Main Menu Functions
    // ======================================
    public void OnPlayGameButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnExitButtonClicked()
    {
        if (Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
}
