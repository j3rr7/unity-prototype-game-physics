using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;


    public bool isGameOver = false;
    private InputAction restartAction;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void RestartPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isGameOver)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void QuitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isGameOver)
            {
                if (Application.isEditor)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
                Application.Quit();
            }       
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
    }
}
