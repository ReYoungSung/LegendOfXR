using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class UIbuttonInteraction : MonoBehaviour
{
    public XRController controller; // Attach your XR Controller in the Unity Inspector.
    public float hapticAmplitude = 0.5f; // Set the haptic amplitude in the Unity Inspector.
    public float hapticDuration = 0.2f;

    private void Start()
    {
    }

    public void OnClickHaptic()
    {
        if (controller != null) 
        {
            controller.SendHapticImpulse(hapticAmplitude, hapticDuration);
        }
    }
}
