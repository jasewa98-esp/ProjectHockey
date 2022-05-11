using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(0);//ints and such also work.
    }
    public void options()
    {
        SceneManager.LoadScene(2);//ints and such also work.
    }

    public void login()
    {
        SceneManager.LoadScene(3);//ints and such also work.
    }
    public void backButton()
    {
        SceneManager.LoadScene(1);//ints and such also work.
    }

}