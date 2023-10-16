using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Scrollbar BGMScrollbar;
    public float currentVolume = 0.5f; // The current volume level

    private void Start()
    {
        // Set the initial value of the Scrollbar to 0.5
        if (BGMScrollbar != null)
        {
            BGMScrollbar.value = currentVolume;
        }
    }

    private void Update()
    {
        // Continuously update the volume based on the Scrollbar value
        AdjustVolume();
    }

    private void AdjustVolume()
    {
        // Ensure the Scrollbar is assigned
        if (BGMScrollbar != null)
        {
            // Set the current volume to the Scrollbar value
            currentVolume = BGMScrollbar.value;
        }
    }

    // This method assumes that you're calling it to play the BGM.
    public void PlayBGM(AudioSource bgmSource)
    {
        if (bgmSource != null)
        {
            bgmSource.volume = currentVolume;  // Set the volume to currentVolume
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }
}