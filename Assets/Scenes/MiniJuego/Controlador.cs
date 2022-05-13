using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Controlador : MonoBehaviour
{
    [SerializeField] private GameObject[] disparoPrefab;
    [SerializeField] private float secondSpawn = 0.5f;
    [SerializeField] private float minTras;
    [SerializeField] private float maxTras;
    public Text puntuacion;
    public int contadorBolas;
    void Start()
    {
        contadorBolas = 0;
        puntuacion.text = "Total de bolas: " + contadorBolas + "/50";
        StartCoroutine(disparoSpawn());
    }

    IEnumerator disparoSpawn()
    {
        contadorBolas++;
        while (contadorBolas != 51)
        {
            puntuacion.text = "Total de bolas: " + contadorBolas + "/50";
            var wanted = Random.Range(minTras, maxTras);
            var wanted2 = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, wanted2);
            GameObject gameObject = Instantiate(disparoPrefab[Random.Range(0, disparoPrefab.Length)], position,
                Quaternion.identity);
            contadorBolas++;
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
