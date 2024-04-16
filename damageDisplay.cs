
using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!
using TMPro;

public class DamageDisplay : MonoBehaviour
{
    public TextMeshPro damageText;  // public if you want to drag your text object in there manually
    int damageCounter;

    void Start()
    {
        damageText = GetComponent<TextMeshPro>(); 
        // if you want to reference it by code - tag it if you have several texts
    }

    void Update()
    {
        damageText.text = knockback.playerDamage.ToString();  // make it a string to output to the Text object
    }
}