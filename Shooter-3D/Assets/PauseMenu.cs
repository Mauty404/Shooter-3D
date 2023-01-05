using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject[] scriptToManage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

        Cursor.lockState = CursorLockMode.Locked;

        foreach(var go in scriptToManage)
        {
            var scripts = go.GetComponents<MonoBehaviour>();
            
            foreach(var script in scripts)
            {
                script.enabled = true;
            }
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;

        Cursor.lockState = CursorLockMode.None;

        foreach(var go in scriptToManage)
        {
            var scripts = go.GetComponents<MonoBehaviour>();
            
            foreach(var script in scripts)
            {
                script.enabled = false;
            }
        }
    }
}
