using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBallBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject ballPlayerPosition;

    [SerializeField]
    Transform porteria;

    [SerializeField]
    float speed = 6f;
    [SerializeField]
    private float stopBallTimer = 2f;

    [SerializeField]
    private float shootingTime = 1f;

    bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Coger Pelotiña
        if (other.tag == "Ball" && !shooting)
        {
            if (ball == null) ball = other.gameObject;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;
            ball.transform.position = new Vector3(0, 0, 0);
            ball.transform.SetParent(this.transform);
            ball.transform.position = ballPlayerPosition.transform.position;
            
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootingTime);
        shooting = true;
        ball.transform.SetParent(null);
        ball.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;
        transform.LookAt(porteria);
        ball.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * speed * 10);
        //Decimos que la pelota, para que no tenga inercia de mas se pare en 2 segundos. 
        yield return new WaitForSeconds(stopBallTimer);
        ball.transform.GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        shooting = false;
        StopCoroutine("Shoot");
    }
}
