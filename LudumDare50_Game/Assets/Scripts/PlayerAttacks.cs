using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Update()
    {
        Attack(); 
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(AttackPoint == null) 
            return;
        
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
