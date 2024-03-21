using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterBasicAttacks : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //weak downground
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isGrounded") == true) && (animator.GetBool("isAttacking") == false)) {
                DownGround();
            }
        }

        //weak downair
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isAirborne") == true) && (animator.GetBool("isAttacking") == false))
            {
                DownAir();
            }
        }

        //weak downair
            if (Input.GetKeyDown(KeyCode.X) && (animator.GetBool("isAirborne") == true) && (animator.GetBool("isAttacking") == false))
            {
                NeutralAir();
            }



    }

    void DownGround()
    {
        Debug.Log("dground");
        animator.SetBool("isDownGrounding", true);
        animator.SetBool("isAttacking", true);
    }

    void endDownGround()
    {
        animator.SetBool("isDownGrounding", false);
        animator.SetBool("isAttacking", false);
    }

    void DownAir()
    {
        Debug.Log("dair");
        animator.SetBool("isDownAiring", true);
        animator.SetBool("isAttacking", true);
    }

    void endDownAir()
    {
        animator.SetBool("isDownAiring", false);
        animator.SetBool("isAttacking", false);
    }
    void NeutralAir()
    {
        Debug.Log("nair");
        animator.SetBool("isNeutralAiring", true);
        animator.SetBool("isAttacking", true);
    }

    void EndNeutralAir()
    {
        animator.SetBool("isNeutralAiring", false);
        animator.SetBool("isAttacking", false);
    }

}
