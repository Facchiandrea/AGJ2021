using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float movementSpeed = 2f;
    float horizontalMovement = 0f;
    public ViewModeSwap viewModeSwap;
    public bool movementBlock = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (viewModeSwap.fullView == false && movementBlock == false && viewModeSwap.transitionToFull == false && viewModeSwap.transitionToSingle == false)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (horizontalMovement > 0f)
            {
                rb.constraints = ~RigidbodyConstraints2D.FreezePosition;

                rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
                spriteRenderer.flipX = false;
            }
            else if (horizontalMovement < 0f)
            {
                rb.constraints = ~RigidbodyConstraints2D.FreezePosition;

                rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
                spriteRenderer.flipX = true;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

        }
        if (viewModeSwap.fullView)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
