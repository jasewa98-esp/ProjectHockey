using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    public GameObject myTarjet;

    public GameObject currentTarget;

    public NavMeshAgent myAgent;

    public int tetherRange;

    public Vector3 startPos;

    public int range;

    void Start()
    {
        InvokeRepeating("DistCheck", 0, 0.5f);

        startPos = this.transform.position;

        myAgent.height = 0.5f;
        myAgent.baseOffset = 0;
    }
    void Update()
    {
        if (currentTarget != null)
        {
            myAgent.destination = currentTarget.transform.position;
        }
        else if (myAgent.destination != startPos)
        {
            myAgent.destination = startPos;
        }
    }

    public void DistCheck()
    {
        float dist = Vector3.Distance(this.transform.position, myTarjet.transform.position);

        if (dist < range)
        {
            currentTarget = myTarjet;
        }
        else if (dist > tetherRange)
        {
            currentTarget = null;
        }
    }

}
