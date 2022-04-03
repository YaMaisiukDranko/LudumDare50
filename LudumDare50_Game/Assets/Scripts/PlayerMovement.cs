using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling, attack1, attack2, attack3 }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            //state = MovementState.running;
            sprite.flipX = false;
            anim.SetBool("running", true);
        }
        else if (dirX < 0f)
        {
            //state = MovementState.running;
            sprite.flipX = true;
            anim.SetBool("running", true);
        }
        else
        {
            //state = MovementState.idle;
            anim.SetBool("idle", true);
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
            anim.SetBool("jumping", true);
            
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        if (Input.GetMouseButtonDown(0))
        {
            int randomAttack = Random.Range(1, 3);
            Debug.Log("Attack!");

            if (randomAttack == 1)
            {
                state = MovementState.attack1;
            }
            else if (randomAttack == 2)
            {
                state = MovementState.attack2;
            }
            else if (randomAttack == 3)
            {
                
            }
        }

        //anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
