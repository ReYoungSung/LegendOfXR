using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

public class XRCMRotationControllerNew : MonoBehaviour
{
    public GameObject XRCM;
    private Rigidbody XRCMRigidbody;
    public float rotationSpeed = 30.0f;

    private void Start()
    {
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();

    }

    public void RotateLeft()
    {
        float rotationAmount = -rotationSpeed * Time.deltaTime;
        float targetRotation = XRCM.transform.eulerAngles.y + rotationAmount;

        if (targetRotation >= 300.0f || targetRotation <= 60.0f)
        {
            XRCM.transform.Rotate(Vector3.up * rotationAmount);
        }
    }

    public void RotateRight()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        float targetRotation = XRCM.transform.eulerAngles.y + rotationAmount;

        if (targetRotation <= 60.0f || targetRotation >= 300.0f)
        {
            XRCM.transform.Rotate(Vector3.up * rotationAmount);
        }
    }
}
