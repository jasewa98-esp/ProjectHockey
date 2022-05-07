using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        //Cross - Play / A - Xbox
        if (Input.GetButtonDown("ButtonDown"))
        {
            
        }
        //Triangle - Play / Y - Xbox
        else if (Input.GetButtonDown("ButtonUp"))
        {
            ResumeGame();
        }
        //Square - Play / X - Xbox
        else if (Input.GetButtonDown("ButtonLeft"))
        {
            GoToMainMenu();
        }
        //Circle - Play / B - Xbox
        else if (Input.GetButtonDown("ButtonRight"))
        {
            QuitGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
