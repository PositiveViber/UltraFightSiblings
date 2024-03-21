using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class knightSpecialAttack : MonoBehaviour
{
    Animator animator;
    private Rigidbody2D rb;

    private int sequenceIndex = 0;
    private float lastKeyPressTime = 0f;
    public float maxTimeBetweenKeys = 60f;

    public float jumpForce = 5f;
    // Update is called once per frame
    private void Start()
    {
       animator = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        KnightUpSpecial();
    }

    void KnightUpSpecial()
    {


        if (sequenceIndex == 0 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
            Debug.Log("1");
        }
        else if (sequenceIndex == 1 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.DownArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
            Debug.Log("2");

        }
        else if (sequenceIndex == 2 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.RightArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
            Debug.Log("3");

        }
        else if (sequenceIndex == 3 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.UpArrow))
        {
            sequenceIndex++;
            lastKeyPressTime = Time.time;
            Debug.Log("4");

        }
        else if (sequenceIndex == 4 && Time.time - lastKeyPressTime <= maxTimeBetweenKeys && Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("isUpSpecialing", true);

            sequenceIndex = 0; // Reset the sequence after successful activation
            Debug.Log("5");

        }
        else if (Time.time - lastKeyPressTime > maxTimeBetweenKeys)
        {
            sequenceIndex = 0; // Reset the sequence if too much time has passed between keys
            rb.velocity = new Vector2(0.0f, 10.0f);
        }
    }

    void KnightStopUpSpecialAttack()
    {
        animator.SetBool("isUpSpecialing", false);
    }
}
