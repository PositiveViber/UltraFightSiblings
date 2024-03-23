using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        CheckGroundAttacks();
        CheckAirborneAttacks();
    }

   // Simple Boolean Key Combo Check (Ground)
   void CheckGroundAttacks()
    {
        // Ground Attacks
        if (animator.GetBool("isGrounded"))
        {
            // Weak DownGround
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.X))
                DownGround(false);

            // Weak DownGround
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.X))
                DownGround(false);

            // Weak UpGround
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.X))
                UpGround(false);

            // Strong UpGround
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Z))
                UpGround(true);

            // Weak SideGround
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.X))
                SideGround(false);

            // Strong SideGround
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.Z))
                SideGround(true);

            // Weak NeutralGround
            if (Input.GetKeyDown(KeyCode.X))
                NeutralGround(false);
            // Strong NeutralGround
            if (Input.GetKeyDown(KeyCode.Z))
                NeutralGround(true);
        }
    }

    // Simple Boolean Key Combo Check (Airborne)
    void CheckAirborneAttacks()
    {
        // Airborne Attacks
        if (animator.GetBool("isAirborne"))
        {
            // Weak UpAir
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.X))
                UpAir(false);

            // Strong UpAir
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Z))
                UpAir(true);

            // Weak SideAir
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.X))
                SideAir(false);

            // Strong SideAir
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyDown(KeyCode.Z))
                SideAir(true);

            // Weak DownAir
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.X))
                DownAir(false);

            // Strong DownAir
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Z))
                DownAir(true);

            // Weak NeutralAir
            if (Input.GetKeyDown(KeyCode.X))
                NeutralAir(false);

            // Strong NeutralAir
            if (Input.GetKeyDown(KeyCode.Z))
                NeutralAir(true);
        }
    }

    """
    Here, we are assuming our strong attacks are using the SAME animations for the regular attacks, here we will further add logic for
    determining the difference between attacks STRONG/WEAK. (I.E. damage values, knockback)

    Usage:
    Boolean to determine text,
    Animator changes for character sprite
    """
    void UpGround(bool strong)
    {
        Debug.Log(strong ? "Strong UpGround" : "Weak UpGround");
        animator.SetBool("isUpGrounding", true);
        animator.SetBool("isAttacking", true);
    }

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
        animator.SetBool("isNeutralAiring", strong);
        animator.SetBool("isAttacking", true);
    }

    void DownAir(bool strong)
    {
        Debug.Log(strong ? "Strong DownAir" : "Weak DownAir");
        animator.SetBool("isDownAiring", true);
        animator.SetBool("isAttacking", true);
    }

}
