using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this toggles a component (usually an Image or Renderer) on and off for an interval to simulate a blinking effect

public class BlinkOn : MonoBehaviour
{
    // Start is called before the first frame update
 
        public GameObject imageToToggle;
        private float interval = 2f;
        private float startDelay = 0f;
        
        // public AudioClip clip;
		
    void Start()
	{
		imageToToggle.SetActive(true);								
		StartBlink();
	}

    public void StartBlink()
	{
		InvokeRepeating("ToggleState", startDelay, interval);		
	}

	public void ToggleState()
	{
		Invoke("blinkActiveFalse", 1f); 
		// plays the clip at (0,0,0)
		// if (clip)
		// 	AudioSource.PlayClipAtPoint(clip,Vector3.zero); 
	}
	
	public void blinkActiveFalse()
	{
		imageToToggle.SetActive(false);

		Invoke("blinkActiveTrue", 1f); 
	}

	public void blinkActiveTrue()
	{
		imageToToggle.SetActive(true);

	}

}
