using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class status : MonoBehaviour
{
    public static Animator animator;
    private static bool grounded = true;
    private static bool attacking = false;
    private static bool inAir = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public static Boolean getGrounded() {
        return grounded;
    }
    public static void setGrounded(bool status)
    {
        grounded = status;
    }

    public static Boolean getAiring()
    {
        return inAir;
    }
    public static void setAiring(bool status)
    {
        inAir = status;
    }

    public static Boolean getAttacking()
    {
        return false;
    }
    public static IEnumerator startAttacking(int attackLength)
    {
        attacking = true;
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("isAttacking", false);
        attacking = false;

    }
}
