using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRCMRotationController : MonoBehaviour
{
    public GameObject XRCM;
    private Rigidbody XRCMRigidbody;

    public enum ButtonType
    {
        Left,
        Right
    }

    public ButtonType buttonType = ButtonType.Left;
    
    public float rotationSpeed = 30.0f;

    private bool isLeftButtonPressed = false; 
    private bool isRightButtonPressed = false; 

    public Transform button;
    public float pressDepth = 0.01f;

    private void Start()
    {
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            SetButtonState(true);
            AnimateButtonPress();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            SetButtonState(false);
            AnimateButtonRelease();
        }
    }

    private void Update() 
    {
        if (isLeftButtonPressed)
        {
            RotateLeft(); 
        }
        else if (isRightButtonPressed)
        {
            RotateRight(); 
        }
    }

    public void SetButtonState(bool isPressed)
    {
        if (buttonType == ButtonType.Left)
        {
            isLeftButtonPressed = isPressed; 
        }
        else if (buttonType == ButtonType.Right)
        {
            isRightButtonPressed = isPressed; 
        }
    }

    void RotateLeft() 
    {
        float rotationAmount = -rotationSpeed * Time.deltaTime;
        float targetRotation = XRCM.transform.eulerAngles.y + rotationAmount;

        if (targetRotation >= 300.0f || targetRotation <= 60.0f)
        {
            XRCM.transform.Rotate(Vector3.up * rotationAmount);
        }
    }

    void RotateRight() 
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        float targetRotation = XRCM.transform.eulerAngles.y + rotationAmount;

        if (targetRotation <= 60.0f || targetRotation >= 300.0f)
        {
            XRCM.transform.Rotate(Vector3.up * rotationAmount);
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
