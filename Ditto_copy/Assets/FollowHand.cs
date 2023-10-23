using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
    public Transform handTransform; // Reference to the avatar's hand transform.

    void Update()
    {
        if (handTransform != null)
        {
            // Update the position and rotation of the UI canvas to match the hand.
            transform.position = handTransform.position;
            transform.rotation = handTransform.rotation;
        }
    }
}