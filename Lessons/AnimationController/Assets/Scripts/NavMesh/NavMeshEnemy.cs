using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public NavMeshObstacle obstacle;

    public NavMeshController player;

    public bool following = false;

    public float restTime = 2;
    float startResting;
    public float distance = 3;
    Vector3 offset;

    private void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
        offset = player.GetFreeTargetPosition();
        agent.speed += Random.Range(-.5f, .5f);
        restTime += Random.Range(-1.7f, 1.7f);
        distance += Random.Range(-1.7f, 1.7f);
        startResting = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-startResting>restTime)
        {
            agent.destination = player.transform.position + offset;

        }

        if (agent.pathStatus== NavMeshPathStatus.PathComplete)
        {
            Vector3 distanceV = (this.transform.position - player.transform.position);
            if (distanceV.magnitude<distance) startResting = Time.time;
        }



        /*
        if (agent.enabled && agent.remainingDistance<1)
        {
            agent.isStopped = true;
            agent.enabled = false;
            obstacle.enabled = true;
        }
        else
        {
            Vector3 distance = this.transform.position - player.position;
            if (following && distance.sqrMagnitude>2*2)
            {
                agent.enabled = true;
                obstacle.enabled = false;
                agent.destination = player.transform.position;
            }

        }
        */

    }
}
