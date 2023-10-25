using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestFloating : MonoBehaviour
{
    public float floatSpeed = 1.0f;  // Speed of the floating motion
    public float floatAmplitude = 1.0f;  // Amplitude of the floating motion

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position based on a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // Update the object's position with the new Y value
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
