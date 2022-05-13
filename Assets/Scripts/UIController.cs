using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    #region Singleton


    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    public Text ScoreText;

    public Text TimerText;
    public int MatchTime = 120;
    private float StartTime = 0;
    public static int p1Score = 0;
    public int p2ScoreBBDD = 0;
    public static int p2Score = 0;    
    private bool MatchActive = false;
    [SerializeField] private CanvasGroup endCanvas;

    public static float elapsedTime;

    bool timeOver = false;
    void Start()
    {
        ResetTimers();
        elapsedTime = MatchTime;
    }

    public void IncrementScore()
    {
        //Hacemos que no cuenten los goles una vez el timer llega a 0
        //En el producto final, cuando el timer llegue a 0 se acabará el partido
        if(MatchActive)
        {
            ScoreText.text = "Score: " + p1Score.ToString() + " - " + p2Score.ToString();
            p2ScoreBBDD = p2Score;
        }
    }

    void Update()
    {
        if (!timeOver) 
        {
            if(elapsedTime > 0)
            {
                elapsedTime -= Time.deltaTime;

                SetTimeDisplay (elapsedTime);
            }
            else
            {
                MatchActive = false;
                SetTimeDisplay(0);
            }
        }
        else if (timeOver)
        {
            if(endCanvas.alpha != 1) endCanvas.alpha = 1;
            Time.timeScale = 0f;
            //Triangle - Play / Y - Xbox
            if (Input.GetButtonDown("ButtonUp"))
            {
                GameOver();
                Time.timeScale = 1f;
            }
            //Square - Play / X - Xbox
            else if (Input.GetButtonDown("ButtonLeft"))
            {
                GoToMainMenu();
                Time.timeScale = 1f;
            }
        }
    }

    private void GameOver()
    {
        GameManager.instance.GameOver();
        endCanvas.alpha = 0;
    }

    public void SetTimeDisplay(float TimeDisplay)
    {
        int SecondsToShow = Mathf.CeilToInt(TimeDisplay);
        int Seconds = SecondsToShow % 60;
        string SecondsDisplay = (Seconds < 10) ? "0" + Seconds.ToString() : Seconds.ToString();
        int Minutes = (SecondsToShow - Seconds) / 60;
        TimerText.text = "Time: " + Minutes.ToString() + ":" + SecondsDisplay;
        if (TimeDisplay <= 0) timeOver = true;
    }

    public void ResetTimers()
    {
        timeOver = false;
        SetTimeDisplay(MatchTime);
        StartTime = Time.time;
        MatchActive = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetScores(int p1, int p2)
    {
        p1Score = p1;
        p2Score = p2;
        ScoreText.text = "Score: " + p1Score.ToString() + " - " + p2Score.ToString();
        p2ScoreBBDD = p2Score;
    }

    public void SetTime(float time)
    {
        elapsedTime = time;
    }
}
