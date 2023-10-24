using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressedSound : MonoBehaviour
{
    public AudioSource buttonAudio;
    // Start is called before the first frame update

    public void PlaySound() 
    {
        if (buttonAudio != null) 
        {
            buttonAudio.Play();
        }
    }
}
