using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class textScript : MonoBehaviour
{
    public TextMeshProUGUI warriorCounterText;
    public int warriorCounter;

    // Ensure that damageClass is accessible and the bladeKeeperDamage is public.
    // You may also need a reference to an instance of damageClass if it's not static.

    public void Start()
    {
        warriorCounterText = GetComponent<TextMeshProUGUI>();
        if (warriorCounterText == null)
        {
            Debug.LogError("Text component not found!");
            return;
        }

        // Set an initial value for debugging purposes
        warriorCounterText.text = "Initial Value";
    }

    public void Update()
    {
        warriorCounter = damageClass.warriorDamage;
        Debug.LogError(warriorCounter);
        if (warriorCounterText == null)
        {
            Debug.LogError("Text component is null!");
            return;
        }

        // Debug to check if Update is being called
        Debug.Log("Update being called.");

        // You must ensure bladeKeeperDamage is being correctly updated in damageClass
        warriorCounterText.text = warriorCounter.ToString();
    }
}
