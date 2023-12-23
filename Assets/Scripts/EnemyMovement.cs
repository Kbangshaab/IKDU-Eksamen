using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private AggroDetection aggroDetection;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetectionOnOnAggro;
    }

    private void AggroDetectionOnOnAggro(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
           
            float currentSpeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed",currentSpeed);
        }
    }
}
