using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 ogPosition;
    // Start is called before the first frame update
    void Start()
    {
        ogPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPositionMethod()
    {
        gameObject.transform.position = ogPosition;
    }
}
