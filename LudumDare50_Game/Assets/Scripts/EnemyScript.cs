using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator _animator;
    private float dirX = 0f;
    private Rigidbody rb;
    private Transform enemyTransform;
    private SpriteRenderer enemySprite;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();
        enemySprite = GetComponent<SpriteRenderer>();
        _animator.SetTrigger("walk");
    }

    private void OnTriggerEnter(Collider other)
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
