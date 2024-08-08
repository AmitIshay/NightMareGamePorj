using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false; // Changed to private
    [SerializeField] float turnSpeed = 5f;
    EnemyHealth health;
    Transform target;

    public bool IsProvoked // Added a public property to access isProvoked
    {
        get { return isProvoked; }
        private set { isProvoked = value; }
    }
     // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;


    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            IsProvoked = true;
            GetComponent<PatrolScript>().enabled = false; // Disable the patrol script when provoked

        }
    }

    public void OnDamageTaken()
    {
        IsProvoked = true;
        GetComponent<PatrolScript>().enabled = false; // Disable the patrol script when provoked

    }
    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);

    }
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*turnSpeed);
    }
    void OnDrawGizmosSelected() {

        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    
    }
        void OnCollisionEnter(Collision collision)
    {
        // Handle collision with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with the player!");
            // Implement collision response (e.g., deal damage to the player)
        }
    }
}
