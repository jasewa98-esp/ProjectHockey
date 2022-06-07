using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mpuStick : MonoBehaviour
{

    public SerialHandlerStick serialHandler;
    public GameObject NorthStar;

    

    // Use this for initialization
    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnDataReceived(string message)
    {
        print(message);
        try
        {
            string value = message;
            string[] vectorPosicion = value.Split('/');
            
            
            string[] vectorX = vectorPosicion[0].Split(".");
            string[] vectorY = vectorPosicion[1].Split(".");
            float x = float.Parse(vectorX[0]) + (float.Parse(vectorX[1]) / 100);
            float y = float.Parse(vectorY[0]) + (float.Parse(vectorY[1]) / 100);
            NorthStar.transform.rotation = Quaternion.Euler(x, y, -90f);
            //transform.rotation = Quaternion.Euler(x, y, z);
            //print("Posicion x -> " + x + " Posicion y -> " + y + " Posicion z -> " + z);
            
            
            print(value);
            
        }
        catch (Exception e)
        {
            
            Debug.LogWarning(e.Message + "AQUI - PALO");
        }
    }
}
