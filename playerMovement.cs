using System;
using System.Collections;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class playerMovement : MonoBehaviour
{
    public status status;
    float horizontalInput;
    public float moveSpeed = 5f;
    // Adjust the jump force as needed
    public float jumpForce = 5f;
    // Flag to check if the player is grounded
    
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;

    private Animator animator;
    //Charcater faces right on start up

    private bool isFacingRight = true;
    private bool isAttacking = false;
    private bool isGrounded = true;
    private bool isAirborne = false;
    private bool doubleJump = true;


    
    private float timeBtwAttack;
    private float startTimeAttack;


    public Transform attackPos;
    private LayerMask enemiesLayer;
    private float attackRange;
    public int damage;

    public KeyCode[] combo;
    public int currentIndex = 0;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        Orientation();

        UpSpecial();

        DoubleJump();

        Jump();

        HorizontalMovements();
    }

    

    void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
    }

    void Grounded()
    {
        animator.SetBool("isGrounded", true);
        animator.SetBool("isAirborne", false);
        isGrounded = true;
        isAirborne = false;
        doubleJump = true;

    }
    void Airborne()
    {
        animator.SetBool("isAirborne", true);
        animator.SetBool("isGrounded", false);
        isAirborne = true;
        isGrounded = false;

    }

    void DoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isAirborne == true && doubleJump == true)
        {
            rb.velocity = new Vector2(0.0f, 5.0f);
            doubleJump = false;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            Airborne();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Orientation()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Smoothly move the character left or right
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void UpSpecial()
    {
      


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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Grounded();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Airborne();
    }


}
