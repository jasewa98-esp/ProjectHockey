using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stick : MonoBehaviour
{
    public int contador;

    public Text puntuacion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        contador = 0;
        puntuacion.text = "Disparos parados: " + contador;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        contador++;
        puntuacion.text = "Disparos parados: " + contador;
    }
}
