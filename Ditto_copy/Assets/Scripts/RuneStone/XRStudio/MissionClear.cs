using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionClear : MonoBehaviour
{
    private GameManager gameManager;

    public Transform button;
    public float pressDepth = 0.01f;

    void Awake()
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            AnimateButtonPress();
            gameManager.getFinishCMButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            AnimateButtonRelease();
            gameManager.getFinishCMButton = false;
        }
    }


    void AnimateButtonPress()
    {
        Vector3 newPosition = button.localPosition;
        newPosition.y -= pressDepth;
        button.localPosition = newPosition;
    }

    void AnimateButtonRelease()
    {
        Vector3 newPosition = button.localPosition;
        newPosition.y += pressDepth;
        button.localPosition = newPosition;
    }
}
