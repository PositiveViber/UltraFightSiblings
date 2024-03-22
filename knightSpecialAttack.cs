using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class knightSpecialAttack : MonoBehaviour
{
    //Declare

    Animator animator;
    private Rigidbody2D rb;

    private int sequenceIndex = 0;
    private float lastKeyPressTime = 0f;
    public float maxTimeBetweenKeys = 60f;

    public float jumpForce = 5f;
    public float sideForce = 5f;

    // Instatiate

    private void Start()
    {
       animator = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        KnightUpSpecial();
        KnightDownSpecial();
        KnightNeutralSpecial();
        KnightSideSpecial();
    }

    //Series of Speical Attacks

    void KnightUpSpecial()
    {
        if (sequenceIndex == 0 && Input.GetKeyDown(KeyCode.RightArrow) || sequenceIndex == 0 && Input.GetKeyDown(KeyCode.LeftArrow)) //Added Left or Right to start 'combo'
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
        }
        else if (sequenceIndex == 4 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("isUpSpecialing", true);

            sequenceIndex = 0; // Reset the sequence after successful activation
            Debug.Log("Up Active");
        }
        else if (Time.time - lastKeyPressTime > maxTimeBetweenKeys)
        {
            sequenceIndex = 0; // Reset the sequence if too much time has passed between keys

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Apply force upwards
        }
    }

    void KnightStopUpSpecialAttack()
    {
        animator.SetBool("isUpSpecialing", false);
    }

    void KnightDownSpecial()
    {
        if (sequenceIndex == 0 && Input.GetKeyDown(KeyCode.RightArrow) || sequenceIndex == 0 && Input.GetKeyDown(KeyCode.LeftArrow)) //Added Left or Right to start 'combo'
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
        else if (sequenceIndex == 3 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.DownArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 4 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("isDownSpecialing", true);

            sequenceIndex = 0; // Reset the sequence after successful activation
            Debug.Log("Down Active");

        }
        else if (Time.time - lastKeyPressTime > maxTimeBetweenKeys)
        {
            sequenceIndex = 0; // Reset the sequence if too much time has passed between keys
            rb.velocity = new Vector2(0.0f, 10.0f);
        }
    }

    void KnightStopDownSpecialAttack()
    {
        animator.SetBool("isDownSpecialing", false);
    }

    void KnightSideSpecial()
    {


        if (sequenceIndex == 0 && Input.GetKeyDown(KeyCode.RightArrow) || sequenceIndex == 0 && Input.GetKeyDown(KeyCode.LeftArrow)) //Added Left or Right to start 'combo'
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
        else if (sequenceIndex == 3 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 4 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.X))
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

    void KnightNeutralSpecial();
    {
        if (sequenceIndex == 0 && Input.GetKeyDown(KeyCode.RightArrow))
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
        else if (sequenceIndex == 3 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.DownArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
        }
        else if (sequenceIndex == 4 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.X))
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

    void KnightStopNeutralSpecial();
    {
        animator.SetBool("isNeutralSpecialing", false);
    }
}
