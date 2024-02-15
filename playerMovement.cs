using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    float horizontalInput;
    public float moveSpeed = 5f;
    // Adjust the jump force as needed
    public float jumpForce = 10f;
    // Flag to check if the player is grounded

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;

    private Animator animator;
    //Charcater faces right on start up

    private bool isFacingRight = true;


    private bool isGrounded;
    private bool isAiring;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        horizontalInput = Input.GetAxis("Horizontal");

        // Smoothly move the character left or right
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", !isGrounded);
        }

        HorizontalMovements();
        UpdateSprite();

        Debug.Log(isGrounded);
    }

    void LateUpdate()
    {
        // Screen bounds check
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x),
            Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y),
            transform.position.z
        );
    }

    private void UpdateSprite()
    {
        // If the player is facing right, use the right facing sprite
        // Otherwise, use the left facing sprite
        //spriteRenderer.sprite = isFacingRight ? rightFacingSprite : leftFacingSprite;
    }

    private void HorizontalMovements()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
