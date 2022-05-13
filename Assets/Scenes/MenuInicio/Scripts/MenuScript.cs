using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }
    public void play()
    {
        SceneManager.LoadScene(3);//ints and such also work.
    }
    public void game()
    {
        SceneManager.LoadScene("Game");//ints and such also work.
    }
    public void options()
    {
        SceneManager.LoadScene("Options");//ints and such also work.
    }

    public void login()
    {
        SceneManager.LoadScene("LoginScene");//ints and such also work.
    }
    public void backButton()
    {
        SceneManager.LoadScene("MainMenu");//ints and such also work.
    }

}