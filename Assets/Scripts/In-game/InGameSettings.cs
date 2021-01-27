using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSettings : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if (GamePaused)
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
        GamePaused = false;
        //GameManager.IsInputEnabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GamePaused = true;
        //GameManager.IsInputEnabled = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
