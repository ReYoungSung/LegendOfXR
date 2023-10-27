using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiToToggle; // Drag and drop the UI element you want to toggle in the inspector.

    private bool isUIVisible = false;


    public void ToggleUI()
    {
        isUIVisible = !isUIVisible; 
        uiToToggle.SetActive(isUIVisible); 
    }
}