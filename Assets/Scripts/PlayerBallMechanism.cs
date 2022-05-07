using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBallMechanism : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    [SerializeField]
    float speed = 6f;
    [SerializeField]
    private float stopBallTimer = 2f;

    bool shooting = false;


    // Update is called once per frame
    void Update()
    {
        //poner condicion de hacer solo si tienes a la pelota como hija
            if (Input.GetButtonDown("Fire1") && ball.transform.parent != null)
            {
                StartCoroutine("Shoot");
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Coger Pelotiña
        if(other.tag == "Ball" && !shooting)
        {
            if(ball == null) ball = other.gameObject;

            ball.transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;
            ball.transform.SetParent(this.transform);
            ball.transform.localPosition = transform.GetChild(3).localPosition;
        }
    }

    private IEnumerator Shoot()
    {
        shooting = true;
        ball.transform.SetParent(null);
        ball.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * speed*10);
        //Decimos que la pelota, para que no tenga inercia de mas se pare en 2 segundos. 
        yield return new WaitForSeconds(stopBallTimer);
        ball.transform.GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Rigidbody>().velocity= Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        shooting = false;
        StopCoroutine("Shoot");
    }


    public void ResetBall()
    {
        ball.transform.SetParent(null);
        ball.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;
        ball.transform.GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
