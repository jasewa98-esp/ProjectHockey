using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoteroBehaviour : MonoBehaviour
{

    public float t = 1f; // speed
    public float l = 10f; // length from 0 to endpoint.
    public float posX = 1f; // Offset

    void Update()
    {
        Vector3 pos = new Vector3(posX + Mathf.PingPong(t * Time.time, l), transform.position.y, transform.position.z);
        transform.position = pos;
    }
}
