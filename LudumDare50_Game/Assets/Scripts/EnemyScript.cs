using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator _animator;
    private float dirX = 0f;
    private Rigidbody rb;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
}
