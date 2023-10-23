using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnButtonSelected()
    {
        // Play sound effect when the button is selected
        audioSource.Play();
    }

    public void OnButtonPressed()
    {
        // Play sound effect when the button is pressed
        audioSource.Play();
        // Add any additional button press logic here
    }
}
