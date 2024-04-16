using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageClass : MonoBehaviour
{
    knockback KnockbackHandler;
    LayerMask mask, mask2, mask3, mask4;
    public int damage = 0;
    public static int bladeKeeperDamage = 0;
    public static int maulerDamage = 0;
    public static int knightDamage = 0;
    public static int warriorDamage = 0;
    Animator animator;
    void Start()
    {
        mask = LayerMask.GetMask("Warrior");
        mask2 = LayerMask.GetMask("Bladekeeper");
        mask3 = LayerMask.GetMask("Knight");
        mask4 = LayerMask.GetMask("Mauler");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("bladekeeper"))
        {
            BladeKeeperDamage();
        }
        else if(animator.GetBool("knight"))
        {
            KnightDamage();
        }
        else if(animator.GetBool("mauler"))
        {
            MaulerDamage();
        }
        else if(animator.GetBool("warrior"))
        {
            WarriorDamage();
        }
        
    }

    public void KnightDamage()
    {
        knightDamage = animator.GetInteger("damage");
    }
    public void MaulerDamage()
    {
        maulerDamage = animator.GetInteger("damage");
    }
    public void BladeKeeperDamage()
    {
        bladeKeeperDamage = animator.GetInteger("damage");
    }
    public void WarriorDamage()
    {
        warriorDamage = animator.GetInteger("damage");
    }
}
