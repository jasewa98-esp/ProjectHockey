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
    public Transform resetPosition;
    public GameObject player;
    public int MatchTime = 120;
    private float StartTime = 0;
    public static int p1Score = 0;
    public static int p2Score = 0;    
    private bool MatchActive = false;
    [SerializeField] private GameObject endCanvas = null;


    bool timeOver = false;
    bool justOnce = false;
    void Start()
    {
        ResetTimers();
    }

    public void IncrementScore()
    {
        //Hacemos que no cuenten los goles una vez el timer llega a 0
        //En el producto final, cuando el timer llegue a 0 se acabará el partido
        if(MatchActive)
        {
            ScoreText.text = "Score: " + p1Score.ToString() + " - " + p2Score.ToString();
        }
    }

    void Update()
    {
        if (!timeOver) 
        {
            if(Time.time-StartTime < MatchTime)
            {
                float ElapsedTime = Time.time - StartTime;
                SetTimeDisplay (MatchTime - ElapsedTime);
            }
            else
            {
                MatchActive = false;
                SetTimeDisplay(0);
                TimerText.color = Color.red;
            }
        }
        else if (timeOver && !justOnce)
        {
            GameManager.instance.GameOver();
            justOnce = true;
        }
    }

    private void SetTimeDisplay(float TimeDisplay)
    {
        int SecondsToShow = Mathf.CeilToInt(TimeDisplay);
        int Seconds = SecondsToShow % 60;
        string SecondsDisplay = (Seconds < 10) ? "0" + Seconds.ToString() : Seconds.ToString();
        int Minutes = (SecondsToShow - Seconds) / 60;
        TimerText.text = "Time: " + Minutes.ToString() + ":" + SecondsDisplay;

        if (TimeDisplay <= 0) timeOver = true;
    }

    public void ResetPosition()
    {   
        player.transform.position = resetPosition.transform.position;
    }

    public void ResetTimers()
    {
        timeOver = false;
        justOnce = false;
        SetTimeDisplay(MatchTime);
        StartTime = Time.time;
        MatchActive = true;
    }


}
