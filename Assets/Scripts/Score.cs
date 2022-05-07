using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    //Detectem si hi ha un gol i si hi ha, cridem al manager
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerGoal/P1"))
        {
            StartCoroutine(GameManager.instance.GoalMethod(1));

        }
        if (other.CompareTag("PlayerGoal/P2"))
        {
            StartCoroutine(GameManager.instance.GoalMethod(2));
        }
    }
}
