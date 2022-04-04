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

    private bool IsGrounded(bool b)
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    
    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded(true))
        {
            Debug.Log("JUMP");
            //jumpSoundEffect.Play();
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
            anim.SetTrigger("running");
        }
        else if (dirX < 0f)
        {
            //state = MovementState.running;
            sprite.flipX = true;
            anim.SetTrigger("running");
        }
        else
        {
            //state = MovementState.idle;
            anim.SetTrigger("idle");
        }

        if (rb.velocity.y > .1f && !IsGrounded(true))
        {
            state = MovementState.jumping;
            anim.SetTrigger("jumping");
            
        }
        else if (rb.velocity.y < -.1f && !IsGrounded(true))
        {
            //state = MovementState.falling;
            anim.SetTrigger("falling");
        }
        else
        {
            if (IsGrounded(true))
            {
                anim.SetTrigger("grounded");
            }
        }

        

        //anim.SetInteger("state", (int)state);
    }
    

    
}
