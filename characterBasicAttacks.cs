using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterBasicAttacks : MonoBehaviour
{
    //Declare

    private Rigidbody2D rb;
    private Animator animator;



    // Instatiate

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (!animator.GetBool("readyToSpecial")) {
            CheckGroundAttacks();
            CheckAirborneAttacks();
        }
    }

   // Simple Boolean Key Combo Check (Ground)
   void CheckGroundAttacks()
    {

        // Ground Attacks
        if (animator.GetBool("isGrounded"))
        {
            // Weak DownGround
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isAttacking") == false))
                DownGround(false);


            // Strong DownGround
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Z) && (animator.GetBool("isAttacking") == false))
                DownGround(false);

            // Weak SideGround
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isAttacking") == false))
                SideGround(false);


            // Strong SideGround
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.Z) && (animator.GetBool("isAttacking") == false))
                SideGround(true);

            // Weak NeutralGround
            if (Input.GetKeyDown(KeyCode.X) && (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) && (animator.GetBool("isAttacking") == false))
                NeutralGround(false);

            // Strong NeutralGround
            if (Input.GetKeyDown(KeyCode.Z) && (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) && (animator.GetBool("isAttacking") == false))
                NeutralGround(true);

            // Ground Guard
            if (Input.GetKey(KeyCode.LeftShift) && (animator.GetBool("isAttacking") == false))
            {
                GroundGuard();
            }
           
        }
      
    }

    // Simple Boolean Key Combo Check (Airborne)
    void CheckAirborneAttacks()
    {
        // Airborne Attacks
        if (animator.GetBool("isAirborne"))
        {
            // Weak NeutralAir
            if (Input.GetKeyDown(KeyCode.X) && (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) && (animator.GetBool("isAttacking") == false))
                NeutralAir(false);

            // Strong NeutralAir
            if (Input.GetKeyDown(KeyCode.Z) && (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) && (animator.GetBool("isAttacking") == false))
                NeutralAir(true);

            // Weak SideAir
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isAttacking") == false))
                SideAir(false);
            // Strong SideAir
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.Z) && (animator.GetBool("isAttacking") == false))
                SideAir(true);
            // Weak UpAir
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isAttacking") == false))
                UpAir(false);
            // Strong UpAir
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Z) && (animator.GetBool("isAttacking") == false))
                UpAir(true);
            // Weak DownAir
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isAttacking") == false))
                DownAir(false);
            // Strong DownAir
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Z) && (animator.GetBool("isAttacking") == false))
                DownAir(true);
            // Air Guard
            if (Input.GetKey(KeyCode.LeftShift) && (animator.GetBool("isAttacking") == false))
                AirGuard();
        }
    }

    /*
    Here, we are assuming our strong attacks are using the SAME animations for the regular attacks, here we will further add logic for
    determining the difference between attacks STRONG/WEAK. (I.E. damage values, knockback)

    Usage:
    Boolean to determine text,
    Animator changes for character sprite
    */


    void SideGround(bool strong)
    {
        Debug.Log(strong ? "Strong SideGround" : "Weak SideGround");
        animator.SetBool("isSideGrounding", true);
        animator.SetBool("isAttacking", true);
    }

    void DownGround(bool strong)
    {
        Debug.Log(strong ? "Strong DownGround" : "Weak DownGround");
        animator.SetBool("isDownGrounding", true);
        animator.SetBool("isAttacking", true);
    }

    void NeutralGround(bool strong)
    {
        Debug.Log(strong ? "Strong NeutralGround" : "Weak NeutralGround");
        animator.SetBool("isNeutralGrounding", true);
        animator.SetBool("isAttacking", true);
    }

    void GroundGuard()
    {
        animator.SetBool("isGroundGuarding", true);
        animator.SetBool("isAttacking", true);
    }

    void UpAir(bool strong)
    {
        Debug.Log(strong ? "Strong UpAir" : "Weak UpAir");
        animator.SetBool("isUpAiring", true);
        animator.SetBool("isAttacking", true);
    }

    void SideAir(bool strong)
    {
        Debug.Log(strong ? "Strong SideAir" : "Weak SideAir");
        animator.SetBool("isSideAiring", true);
        animator.SetBool("isAttacking", true);
    }

    void NeutralAir(bool strong)
    {
        Debug.Log(strong ? "Strong NeutralAir" : "Weak NeutralAir");
        animator.SetBool("isNeutralAiring", true);
        animator.SetBool("isAttacking", true);
    }

    void DownAir(bool strong)
    {
        Debug.Log(strong ? "Strong DownAir" : "Weak DownAir");
        animator.SetBool("isDownAiring", true);
        animator.SetBool("isAttacking", true);
    }

    void AirGuard()
    {
        animator.SetBool("isAirGuarding", true);
        animator.SetBool("isAttacking", true);
    }


    void StopSideGround()
    {
        animator.SetBool("isSideGrounding", false);
        animator.SetBool("isAttacking", false);
    }

    void StopDownGround()
    {
        animator.SetBool("isDownGrounding", false);
        animator.SetBool("isAttacking", false);
    }

    void StopNeutralGround()
    {
        animator.SetBool("isNeutralGrounding", false);
        animator.SetBool("isAttacking", false);
    }

    void StopGroundGuard()
    {
        animator.SetBool("isGroundGuarding", false);
        animator.SetBool("isAttacking", false);
    }


    void StopUpAir()
    {
        animator.SetBool("isUpAiring", false);
        animator.SetBool("isAttacking", false);
    }

    void StopSideAir()
    {
        animator.SetBool("isSideAiring", false);
        animator.SetBool("isAttacking", false);
    }

    void StopNeutralAir()
    {
        animator.SetBool("isNeutralAiring", false);
        animator.SetBool("isAttacking", false);
    }

    void StopDownAir()
    {
        animator.SetBool("isDownAiring", false);
        animator.SetBool("isAttacking", false);
    }

    void StopAirGuard()
    {
        animator.SetBool("isAirGuarding", false);
        animator.SetBool("isAttacking", false);
    }
}
