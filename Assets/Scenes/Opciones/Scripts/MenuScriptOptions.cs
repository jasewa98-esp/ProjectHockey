using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScriptOptions : MonoBehaviour
{
   
    public void backButton()
    {
        SceneManager.LoadScene(1);//ints and such also work.
    }

}