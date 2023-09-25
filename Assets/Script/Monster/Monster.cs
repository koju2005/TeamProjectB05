using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public enum AIState
{
    Idle,
    Wandering,
    Attacking,
    Fleeing
}
public class Monster : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public float walkSpeed;
    public float runSpeed;
    //public ItemData[] dropOnDeath; //Optional

    [Header("AI")]
    private AIState aiState;
    public float detectDistance;
    public float safeDistance;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderwaitTime;
    public float maxWanderWaitTime;

    [Header("Combat")]
    public int damage;
    public float attackRate;
    private float lastAttackTime;
    public float attackDistance;

    private float playerDistance;
    public float fieldOfView = 120f;

    private NavMeshAgent agent;
    private Animator animator;
    private SkinnedMeshRenderer[] meshRenderers;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        SetState(AIState.Wandering);
    }

    private void Update()
    {
        //TODO
        //playerDistance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        animator.SetBool("Moving", aiState != AIState.Idle);

        switch (aiState)
        {
            case AIState.Idle: PassiveUpdate(); break;
            case AIState.Wandering: PassiveUpdate(); break;
            //case AIState.Attacking: AttackingUpdate(); break;
            case AIState.Fleeing: FleeingUpdate(); break;
        }
    }

    private void FleeingUpdate()
    {

    }

    //private void AttackingUpdate()
    //{
    //    if(playerDistance > attackDistance || !IsPlayerInFieldOfView())
    //    {
    //        agent.isStopped = false;
    //        NavMeshPath path = new NavMeshPath();
    //        if(agent.CalculatePath(PlayerController.instance.transform.position, path))
    //        {
    //            agent.SetDestination(PlayerController.instance.transform.postion);
    //        }
    //        else
    //        {
    //            SetState(AIState.Fleeing);
    //        }
    //    }
    //    else
    //    {
    //        agent.isStopped =true;
    //        if(Time.time - lastAttackTime > attackRate)
    //        {
    //            lastAttackTime = Time.time;
    //            PlayerController.instance.GetComponent<IDamagable>().TakePhysicalDamage(damage);
    //            animator.speed = 1;
    //            animator.SetTrigger("Attack");
    //        }
    //    }
    //}

    private void PassiveUpdate()
    {
        if (aiState == AIState.Wandering && agent.remainingDistance < 0.1f)
        {
            SetState(AIState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderwaitTime, maxWanderWaitTime));
        }
        if (playerDistance < detectDistance)
        {
            SetState(AIState.Attacking);
        }
    }

    private void SetState(AIState newState)
    {
        aiState = newState;
        switch (aiState)
        {
            case AIState.Wandering:
                {
                    agent.speed = walkSpeed;
                    agent.isStopped = true;
                }
                break;
            case AIState.Idle:
                {
                    agent.speed = walkSpeed;
                    agent.isStopped = false;
                }
                break;
            case AIState.Attacking:
                {
                    agent.speed = runSpeed;
                    agent.isStopped = false;
                }
                break;
            case AIState.Fleeing:
                {
                    agent.speed = runSpeed;
                    agent.isStopped = false;
                }
                break;
        }
        animator.speed = agent.speed / walkSpeed;
    }
}


