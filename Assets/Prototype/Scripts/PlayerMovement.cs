using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 2f;
    float horizontalMovement = 0f;
    public ViewModeSwap viewModeSwap;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (viewModeSwap.fullView == false)
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            if (horizontalMovement > 0f)
            {
                rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
            }
            if (horizontalMovement < 0f)
            {
                rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
            }
        }

    }
}
