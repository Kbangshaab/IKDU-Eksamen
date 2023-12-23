using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float attackRefreshRate;
    
    private AggroDetection aggroDetection;
    private Health healthTarget;
    private float attackTimer;

    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetectionOnOnAggro;
    }

    private void AggroDetectionOnOnAggro(Transform obj)
    {
        Health health = target.GetComponment<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }

    private void Update()
    {
        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            
            if (CanAttack())
            {
                Attack();
            }
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }
}
