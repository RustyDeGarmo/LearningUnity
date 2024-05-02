using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.Animations;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnspeed = 5f;
    bool isProvoked = false;
    bool damageTaken = false;

    NavMeshAgent navMeshAgent;
    Animator animator;
    EnemyHealth enemyHealth;
    float distanceToTarget = Mathf.Infinity;

    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    
    void Update()
    {
        if(enemyHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if(distanceToTarget > chaseRange && damageTaken == false)
        {
            animator.SetTrigger("idle");
            isProvoked = false;
            navMeshAgent.isStopped = true;
        }

        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
        damageTaken = true;
    }
    
    private void EngageTarget()
    {
        navMeshAgent.isStopped = false;
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnspeed);
    }

    void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        animator.SetBool("attack", true); 
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);     
    }
}
