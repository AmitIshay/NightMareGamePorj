using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrolScript : MonoBehaviour
{
    
    public Transform[] points;
    int current;
    public float speed;
    private NavMeshAgent navMeshAgent;
    private EnemyAI enemyAI;

    void Start ()
    {
        current = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAI = GetComponent<EnemyAI>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing from this game object");
        }
        else
        {
            navMeshAgent.autoBraking = false;
            GotoNextPoint();
        }
    }
    void Update ()
    {
        if (enemyAI.IsProvoked) 
        {
            navMeshAgent.isStopped = true; // Stop patrolling if enemy is chasing the player
            return;
        }

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
        void GotoNextPoint()
    {
        if (points.Length == 0) return;

        navMeshAgent.destination = points[current].position;
        Debug.Log("Going to next point: " + points[current].position); // Debug log
        current = (current + 1) % points.Length;
    }

 }
