using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class knightSpecialAttack : MonoBehaviour
{
    //Declare
    playerMovement neededScript;

    Animator animator;
    private Rigidbody2D rb;

    private int sequenceIndex = 0;
    private float lastKeyPressTime = 0f;
    public float maxTimeBetweenKeys = 15f;

    public float jumpForce = 5f;
    public float sideForce = 5f;

    // Instatiate

    private void Start()
    {
       animator = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
       neededScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame

    void Update()
    {
        KnightUpSpecial();
        if (animator.GetBool("isGrounded") == true)
        {
            KnightNeutralSpecial();
            KnightSideSpecial();
        }
    }

    //Series of Speical Attacks

    void KnightUpSpecial()
    {
        //switch (sequenceIndex)
        //{
        //    case 0:
        //        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        //        {
        //            sequenceIndex++;
        //            lastKeyPressTime = Time.time;
        //            Debug.Log("Up Active");
        //        }
        //        break;

        //    case 1:
        //        if (Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.DownArrow))
        //        {
        //            sequenceIndex++;
        //            lastKeyPressTime = Time.time;
        //            Debug.Log("Up Active");
        //        }
        //        break;

        //    case 2:
        //        if (Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.RightArrow))
        //        {
        //            sequenceIndex++;
        //            lastKeyPressTime = Time.time;
        //            Debug.Log("Up Active");
        //        }
        //        break;

        //    case 3:
        //        if (Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.UpArrow))
        //        {
        //            sequenceIndex++;
        //            lastKeyPressTime = Time.time;
        //            animator.SetBool("readyToSpecial", true);
        //            Debug.Log("Up Active");
        //        }
        //        break;

        //    case 4:
        //        if (Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.X))
        //        {
        //            animator.SetBool("isUpSpecialing", true);
        //            animator.SetBool("readyToSpecial", false);
        //            animator.SetBool("isAttacking", true);

        //            neededScript.SpecialBoost();

        //            sequenceIndex = 0; // Reset the sequence after successful activation
        //            Debug.Log("Up Active");
        //        }
        //        break;
        //}

        //if (sequenceIndex > 0 && Time.time - lastKeyPressTime > maxTimeBetweenKeys)
        //{
        //    // Reset the sequence if too much time has passed between keys, except when sequenceIndex is 0.
        //    animator.SetBool("readyToSpecial", false);
        //    sequenceIndex = 0;
        //}

        if (sequenceIndex == 0 && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))) //Added Left or Right to start 'combo'
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 1 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.DownArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 2 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.RightArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 3 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.UpArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
            animator.SetBool("readyToSpecial", true);
        }
        else if (sequenceIndex == 4 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("isUpSpecialing", true);
            animator.SetBool("readyToSpecial", false);
            animator.SetBool("isAttacking", true);

            neededScript.SpecialBoost();

            sequenceIndex = 0; // Reset the sequence after successful activation
        }
        else if (Time.time - lastKeyPressTime > maxTimeBetweenKeys)
        {
            animator.SetBool("readyToSpecial", false);
            sequenceIndex = 0; // Reset the sequence if too much time has passed between keys
        }
    }

    void KnightStopUpSpecialAttack()
    {
        animator.SetBool("isUpSpecialing", false);
        animator.SetBool("isAttacking", false);
    }


    void KnightNeutralSpecial()
    {

        if (sequenceIndex == 0 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.DownArrow)) //Added Left or Right to start 'combo'
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 1 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 2 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) ))
        {
            animator.SetBool("isSideSpecialing", true);

            sequenceIndex = 0; // Reset the sequence after successful activation
            Debug.Log("Side Active");

        }
        else if (Time.time - lastKeyPressTime > maxTimeBetweenKeys)
        {
            sequenceIndex = 0; // Reset the sequence if too much time has passed between keys
        }
    }

    void KnightStopSideSpecialAttack()
    {
        animator.SetBool("isSideSpecialing", false);
    }

    void KnightSideSpecial()
    {
        
        if (sequenceIndex == 0 && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 1 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.DownArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 2 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 3 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)))
        {
            animator.SetBool("isNeutralSpecialing", true);

            sequenceIndex = 0; // Reset the sequence after successful activation
            Debug.Log("Neutral Active");

        }
        else if (Time.time - lastKeyPressTime > maxTimeBetweenKeys)
        {
            sequenceIndex = 0; // Reset the sequence if too much time has passed between keys
        }
    }

    void KnightStopNeutralSpecial()
    {
        animator.SetBool("isNeutralSpecialing", false);
    }
}
