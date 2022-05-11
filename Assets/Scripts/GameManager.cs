using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("OBJETOS A REINICAR POSICIÓN")]
    [SerializeField]
    private ResetPosition[] objetsToReset;

    [SerializeField]
    private PlayerBallMechanism playerBall;
    [HideInInspector]
    public bool isMoving = true;

    [SerializeField]
    StaminaController staminaController;


    //ThingToSave
    [SerializeField]
    private GameObject ball;

    #region Singleton


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveData(UIController.elapsedTime, playerBall.transform.position, ball.transform.position, UIController.p1Score, UIController.p2Score);
            Debug.Log(UIController.p1Score + "  " + UIController.p2Score);
            Debug.Log("SavingData....");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine("LoadData");
            Debug.Log(UIController.p1Score + "  " + UIController.p2Score);
            Debug.Log("LoadingData....");
        }
    }

    /// <summary>
    /// Afegim la puntuació al player corresponent, actualitzem la score y resetegem les posicions.
    /// </summary>
    /// <param name="player"></param>
    public IEnumerator GoalMethod(int player)
    {
        isMoving = false;
        playerBall.ResetBall();
        staminaController.ResetStamina();

        switch (player)
        {   
            case 1:
            UIController.p1Score++;
            break;
            case 2:
            UIController.p2Score++;
            break;
        }
        
        //Debug.Log(UIController.p1Score + " to " + UIController.p2Score);

        UIController.instance.IncrementScore();
        
        foreach (var item in objetsToReset)
        {   
            item.ResetPositionMethod();
        }
        yield return new WaitForSeconds(0.1f);
        isMoving = true;
        StopCoroutine("GoalMethod");
    }

    public void GameOver()
    {
        //Recuerda llamar a esto, cuando el jugador haga otro partido!
        //Volver a empezar partido: llamar a todos los resets blablablaç
        //crear resets de todo
        UIController.instance.ResetTimers();
        UIController.instance.ResetPosition();
    }


    public void SaveData(float Time, Vector3 PlayerPosition, Vector3 BallPosition, int ScorePlayer1, int ScorePlayer2)
    {
        //Timer
        PlayerPrefs.SetFloat("Timer", Time);

        //Player
        PlayerPrefs.SetFloat("PlayerPositionX", PlayerPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", PlayerPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", PlayerPosition.z);

        //NPC (Jajajajajaja, suerte :D)


        //Ball
        PlayerPrefs.SetFloat("BallPositionX", BallPosition.x);
        PlayerPrefs.SetFloat("BallPositionY", BallPosition.y);
        PlayerPrefs.SetFloat("BallPositionZ", BallPosition.z);

        //Scores
        PlayerPrefs.SetInt("ScorePlayer1", ScorePlayer1);
        PlayerPrefs.SetInt("ScorePlayer2", ScorePlayer2);
    }

    public IEnumerator LoadData()
    {
        isMoving = false;
        yield return new WaitForSeconds(0.1f);
        UIController.instance.SetTime(PlayerPrefs.GetFloat("Timer"));

        playerBall.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPositionX"), PlayerPrefs.GetFloat("PlayerPositionY"), PlayerPrefs.GetFloat("PlayerPositionZ"));

        playerBall.ResetBall();
        ball.transform.position = new Vector3(PlayerPrefs.GetFloat("BallPositionX"), PlayerPrefs.GetFloat("BallPositionY"), PlayerPrefs.GetFloat("BallPositionZ"));

        UIController.instance.SetScores(PlayerPrefs.GetInt("ScorePlayer1"), PlayerPrefs.GetInt("ScorePlayer2")); 
        isMoving = true;
        StopCoroutine("LoadData");
    }
}
