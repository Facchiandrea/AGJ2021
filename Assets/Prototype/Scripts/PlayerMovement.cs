using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float movementSpeed = 2f;
    float horizontalMovement = 0f;
    public ViewModeSwap viewModeSwap;
    public bool movementBlock = false;
    public LockManager lockManager;
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {

        if (viewModeSwap.fullView == false && movementBlock == false && viewModeSwap.transitionToFull == false && viewModeSwap.transitionToSingle == false && lockManager.lockPuzzleActive == false)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (horizontalMovement > 0f)
            {
                animator.SetBool("IsWalking", true);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
                spriteRenderer.flipX = false;
            }
            else if (horizontalMovement < 0f)
            {
                animator.SetBool("IsWalking", true);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
                spriteRenderer.flipX = true;
            }
            else
            {
                animator.SetBool("IsWalking", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }

        }
        if (viewModeSwap.fullView)
        {
            animator.SetBool("IsWalking", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
