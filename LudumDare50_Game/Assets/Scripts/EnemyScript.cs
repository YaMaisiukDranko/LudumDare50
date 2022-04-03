using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator _animator;
    private float dirX = 0f;
    private Rigidbody rb;
    public int moveSpeed = 10;
    public bool touchPlayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("attack");
            //Health -
        }

        if (!other.CompareTag("Player") || touchPlayer == true)
        {
            _animator.SetTrigger("walk");
        }
    }
}
