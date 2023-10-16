using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMissionSensor : MonoBehaviour
{
    private GameManager gameManager;

    public enum RotationRange
    {
        M1,
        M2,
        M3
    }

    [SerializeField]
    private RotationRange allowedRotation = RotationRange.M1;

    private void Awake()
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    }

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("XRCamera"))
        {
            
            if (IsRotationWithinRange(other.gameObject.transform)) 
            {
                gameManager.isCameraInExactPlace = true;
            }
            else
            {
                gameManager.isCameraInExactPlace = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("XRCamera"))
        {
            gameManager.isCameraInExactPlace = false;
        }
    }

    private bool IsRotationWithinRange(Transform avatarTransform)
    {
        float rotationY = avatarTransform.eulerAngles.y;

        switch (allowedRotation)
        {
            case RotationRange.M1:
                return (rotationY >= 360f-45f && rotationY <= 360f);
            case RotationRange.M2:
                return (rotationY >= 360f-15f || rotationY <= 15f);
            case RotationRange.M3:
                return (rotationY >= 0f && rotationY <= 45f);
        }

        return false;
    }
}
