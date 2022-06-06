using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlClient;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using Random = UnityEngine.Random;

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
    public static int p2Score = 0;    
    private bool MatchActive = false;
    public string Server = "localhost";
    public string DataBase = "projecte_final_ok";
    public string UserID = "root";
    public string Password = "";
    public bool Pooling = false;
    public bool donete = false;
    [SerializeField] private CanvasGroup endCanvas;
    private int id;

    public static float elapsedTime;

    bool timeOver = false;
    //private string _connectionString = "Server=localhost;Database=projecte_final_ok;Uid=root;Pwd=";
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
            if (!donete)
            {
                Debug.Log("base de datos conexion ...");
                #region Connection to MySQL
                string connectionString =
                  "Server=" + Server + ";" +
                  "Database=" + DataBase + ";" +
                  "User ID=" + UserID + ";" +
                  "Password=" + Password + ";" +
                  "Pooling=" + Pooling.ToString();

                IDbConnection dbcon;
                dbcon = new MySqlConnection(connectionString);
                dbcon.Open();
                #endregion

                IDbCommand dbcmd = dbcon.CreateCommand();
                string sql = "INSERT INTO score (scoreP1, scoreP2) VALUES (" + p1Score + ", " + p2Score + ")"; dbcmd.CommandText = sql;
                IDataReader reader = dbcmd.ExecuteReader();
                donete = true;


                #region clean up
                reader.Close();
                reader = null;

                dbcmd.Dispose();
                dbcmd = null;

                dbcon.Close();
                dbcon = null;
                #endregion


            }

            if (endCanvas.alpha != 1) endCanvas.alpha = 1;
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
    }

    public void SetTime(float time)
    {
        elapsedTime = time;
    }
}
