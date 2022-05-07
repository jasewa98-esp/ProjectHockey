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

    #region Singleton


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    /// <summary>
    /// Afegim la puntuació al player corresponent, actualitzem la score y resetegem les posicions.
    /// </summary>
    /// <param name="player"></param>
    public IEnumerator GoalMethod(int player)
    {
        isMoving = false;
        playerBall.ResetBall();
        switch(player)
        {   
            case 1:
            UIController.p1Score++;
            break;
            case 2:
            UIController.p2Score++;
            break;
        }
        
        Debug.Log(UIController.p1Score + " to " + UIController.p2Score);

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
        //Me sale un canvas con partido acabado


        //Recuerda llamar a esto, cuando el jugador haga otro partido!
        //Volver a empezar partido: llamar a todos los resets blablablaç
        //crear resets de todo
        UIController.instance.ResetTimers();
    }
}
