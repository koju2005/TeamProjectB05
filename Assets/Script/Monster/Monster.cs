using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float maxWanderWaitTiem;

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
        SetStateGraph(AIState.Wandering);
    }

    //private void Update()
    //{
    //    playerDistance = Vector3.Distance(transform.position, Player);
    //}

    private void SetStateGraph(AIState newState)
    {
        aiState = newState;
        switch(aiState)
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
  
  
