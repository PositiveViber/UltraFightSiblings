using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    bool held = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            //continuing attack animation
        }
        else if(!held)
        {
            //single animation
        }

    }

    private void OnAttack()
    {
        held = !held;
    }
}
