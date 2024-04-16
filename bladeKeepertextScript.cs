using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class bladeKeepertextScript : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int counter;

    // Ensure that damageClass is accessible and the bladeKeeperDamage is public.
    // You may also need a reference to an instance of damageClass if it's not static.

    public void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
        if (counterText == null)
        {
            Debug.LogError("Text component not found!");
            return;
        }

        // Set an initial value for debugging purposes
        counterText.text = "Initial Value";
    }

    public void Update()
    {
        counter = damageClass.bladeKeeperDamage;
        Debug.LogError(counter);
        if (counterText == null)
        {
            Debug.LogError("Text component is null!");
            return;
        }

        // Debug to check if Update is being called
        Debug.Log("Update being called.");

        // You must ensure bladeKeeperDamage is being correctly updated in damageClass
        counterText.text = counter.ToString();
    }
}
