using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttacks : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 100;
    private Animator anim;
    private void Start()
    {
        AttackPoint.gameObject.SetActive(false);
    }

    private void Update()
    {
        Attack(); 
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim = GetComponent<Animator>();
            AttackPoint.gameObject.SetActive(false);AttackPoint.gameObject.SetActive(true);
            int randomAttack = Random.Range(1, 3);
            Debug.Log("Attack!");

            if (randomAttack == 1)
            {
                anim.SetTrigger("attack1");
            }
            else if (randomAttack == 2)
            {
                anim.SetTrigger("attack2");
            }
            else if (randomAttack == 3)
            {
                anim.SetTrigger("attack3");
            }
        }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit " + enemy.name);
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            enemy.GetComponent<EnemyFollow>().enabled = false;
        }
        AttackPoint.gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        if(AttackPoint == null) 
            return;
        
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
