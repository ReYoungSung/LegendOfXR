using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSensor : MonoBehaviour
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
        if(other.CompareTag("Avatar"))
        {
            if (allowedRotation == RotationRange.M1)
            {
                other.transform.localRotation = Quaternion.Euler(0, 30f, 0);
            }
            else if (allowedRotation == RotationRange.M2)
            {
                other.transform.localRotation = Quaternion.Euler(0, 30f, 0);
            }
            else if (allowedRotation == RotationRange.M3)
            {
                other.transform.localRotation = Quaternion.Euler(0, 65f, 0);
            }
        
            gameManager.isCharacterInExactPlace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Avatar"))
        {
            gameManager.isCharacterInExactPlace = false;
        }
    }

    private bool IsRotationWithinRange(Transform avatarTransform)
    {
        float rotationY = avatarTransform.rotation.eulerAngles.y;  

        if(allowedRotation == RotationRange.M1)
        {
            return (rotationY >= 360f-90f && rotationY <= 360f);
        }
        else if (allowedRotation == RotationRange.M2) 
        { 
            return (rotationY >= 360f || rotationY <= 90f);     
        }
        else if (allowedRotation == RotationRange.M3)
        {
            return (rotationY >= 360f || rotationY <= 90f);  
        }
        else 
        {
            return false;
        }
    }
}
