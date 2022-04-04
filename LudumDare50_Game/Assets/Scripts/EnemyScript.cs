using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator _animator;
    private float dirX = 0f;
    private Rigidbody rb;
    private Transform enemyTransform;
    private SpriteRenderer enemySprite;
    public ParticleSystem particle;

    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();
        enemySprite = GetComponent<SpriteRenderer>();
        _animator.SetTrigger("walk");
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        particle.Play();
        Destroy(gameObject);
        Debug.Log("enemy die " + name);
        _animator.SetBool("Died", true);
        GetComponent<EnemyFollow>().enabled = false;
        this.enabled = false;
    }

private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTarget"))
        {
            _animator.SetTrigger("idle");
            _animator.SetTrigger("attack");
            //Health -
        }

        if (!other.CompareTag("PlayerTarget"))
        {
            _animator.SetTrigger("walk");
        }
    }

    private void Update()
    {
        particle = GetComponent<ParticleSystem>();
        if (enemyTransform.position.x > 0)
        {
            enemySprite.flipX = true;
        }
        else if (enemyTransform.position.x < 0)
        {
            enemySprite.flipX = false;
        }
    }
}
