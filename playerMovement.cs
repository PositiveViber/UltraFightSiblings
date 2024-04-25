using System;
using System.Collections;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class playerMovement : MonoBehaviour
{
    private Gamepad gamepad;

    buttonController button;
    private Vector3[] startingPositions;
    public int playerStock = 0;
    public GameObject[] sprites; // Assign your sprite GameObjects in the inspector
    private GameObject[] playerSprites;
    public status status;
    float horizontalInput;
    public float moveSpeed = 5f;
    // Adjust the jump force as needed
    public float jumpForce = 5f;
    // Flag to check if the player is grounded
    
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    public Rigidbody2D rb;

    public Animator animator;
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
        playerSprites = GameObject.FindGameObjectsWithTag("Player");
        // Initialize the startingPositions array with the same length as the sprites array
        startingPositions = new Vector3[playerSprites.Length];

        // Store the starting positions of each sprite
        for (int i = 0; i < playerSprites.Length; i++)
        {
            if (playerSprites[i] != null)
            {
                startingPositions[i] = playerSprites[i].transform.position;
            }
        }


        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (gamepad == null) return;


    }

    // Update is called once per frame
    void Update()    
        {
        if (!animator.GetBool("appliedKnockback"))
        { 
            if (!animator.GetBool("isAttacking") || (animator.GetBool("isAirborne")) && animator.GetBool("isAttacking"))
            {
                Orientation();
            }

            if (!animator.GetBool("isAttacking"))
            {
                DoubleJump();
                Jump();
                HorizontalMovements();
            }

        }
    }
    private void OnEnable()
    {
        // Subscribe to the event that is called when a device is connected
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    public void LoadSpriteData()
    {
        playerSprites= GameObject.FindGameObjectsWithTag("Player");
        // Initialize the startingPositions array with the same length as the sprites array
        startingPositions = new Vector3[playerSprites.Length];

        // Store the starting positions of each sprite
        for (int i = 0; i < playerSprites.Length; i++)
        {
            if (playerSprites[i] != null)
            {
                startingPositions[i] = playerSprites[i].transform.position;
            }
        }
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

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            Airborne();
            rb.velocity = new Vector2(0.0f, 5.0f);
        }

    }


    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added)
        {
            gamepad = device as Gamepad;
        }
        else if (change == InputDeviceChange.Removed && device == gamepad)
        {
            // Handle gamepad disconnection
            gamepad = null;
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

    void LateUpdate()
    {
        BoundCheck();
    }

    public void BoundCheck()
    {
        // Screen bounds check
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x ,-screenBounds.x, screenBounds.x),
            Mathf.Clamp(transform.position.y, -screenBounds.y -1f, screenBounds.y),
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

    public void SpecialBoost()
    {
        rb.velocity = new Vector2(0.0f, 10.0f);
    }

    public void RespawnSprites()
    {
        foreach (var player in playerSprites)
        {
            // Find the index of the player to get the correct starting position
            int index = System.Array.IndexOf(playerSprites, player);
            if (index != -1)
            {
                player.transform.position = startingPositions[index];
                player.transform.rotation = Quaternion.identity;
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f; // If you also want to reset any rotational velocity
                }
            }
        }
    }
}
