using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointerChange : MonoBehaviour
{

    public GameObject[] buttons; // Assign your buttons in the inspector
    public GameObject pointer; // Assign your pointer image GameObject in the inspector
    private int selectedIndex = 0; // The index of the currently selected button
    public Vector3 pointerOffset; // Set this in the inspector to adjust the pointer's position relative to the button

    void Start()
    {
        UpdatePointerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSelection(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            ActivateButton();
        }
    }

    void MoveSelection(int direction)
    {
        selectedIndex += direction;
        if (selectedIndex < 0) selectedIndex = buttons.Length - 1;
        else if (selectedIndex > buttons.Length - 1) selectedIndex = 0;
        UpdatePointerPosition();
    }

    void UpdatePointerPosition()
    {
        // Adjust the pointer position to be next to the selected button
        pointer.transform.position = buttons[selectedIndex].transform.position + pointerOffset;
    }

    void ActivateButton()
    {
        // Call the Activate method of the ButtonController attached to the selected button
        buttons[selectedIndex].GetComponent<ButtonController>().Activate();
    }

}

// You would also have a ButtonController script with an Activate method that gets called when a button is selected
public class ButtonController : MonoBehaviour
{
    public void Activate()
    {
        // Perform the button's action, e.g., load a scene, change settings, etc.
        Debug.Log(gameObject.name + " activated!");
    }
}
