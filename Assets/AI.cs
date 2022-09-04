using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
     NavMeshAgent agent;

     Follower follower;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    killable killable;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    Animator animator;
    private void Awake()
    {
        if (follower == null)
        {
            follower = FindObjectOfType<Follower>();
        }
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        killable = GetComponent<killable>();
    }

    private void Update()
    {
        if (killable.health <= 0)
        {
            agent.SetDestination(transform.position);

            return;

        }
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        animator.SetBool("walk", true);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            animator.SetBool("walk", false);
            Invoke("Idle", 5f);
        }
    }
    void Idle()
    {
        walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(follower.transform.position);
    }

    private void AttackPlayer()
    {
        if (follower.GetHealth() <= 0) return;

        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        animator.SetBool("walk", false);
        animator.SetBool("attack", true);
        transform.LookAt(follower.transform);
        if (!alreadyAttacked)
        {
            ///Attack code here
            Shoot();
            ///End of attack code
            Invoke("ResetAttack", 3f);

            alreadyAttacked = true;
        }
    }

    void Shoot()
    {
        follower.dealDamage(2);

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("attack", false);


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
