using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Scrollbar BGMScrollbar;
    public AudioSource SoundManager;

    private void Start()
    {
        // Set the initial value of the Scrollbar to 0.5
        if (BGMScrollbar != null)
        {
            BGMScrollbar.value = 0.5f;
        }
        // Set the initial volume based on the Scrollbar value
        AdjustVolume();
    }

    private void Update()
    {
        // Continuously update the volume based on the Scrollbar value
        AdjustVolume();
    }

    private void AdjustVolume()
    {
        // Ensure the Scrollbar and SoundManager are assigned
        if (BGMScrollbar != null && SoundManager != null)
        {
            // Map the Scrollbar value to the desired volume range (0 to 1)
            float volume = BGMScrollbar.value;

            // Set the volume of the SoundManager to the mapped value
            SoundManager.volume = volume;
        }
    }
}