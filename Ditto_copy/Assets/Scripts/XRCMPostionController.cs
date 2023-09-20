using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCMPostionController : XRGrabInteractable
{
    public GameObject XRCM;
    private Rigidbody XRCMRigidbody;

    public float moveSpeed = 20.0f;

    private float initialZRotation;

    protected override void Awake()
    {
        base.Awake();
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();
        initialZRotation = transform.localEulerAngles.z;
    }

    private void Update()
    {
        if (isSelected)
        {
            float currentZRotation = transform.localEulerAngles.z;
            float rotationDifference = Mathf.DeltaAngle(initialZRotation, currentZRotation);

            Vector3 moveDirection = new Vector3(0, 0, 0);

            if (rotationDifference > 5)
                moveDirection = new Vector3(1, 0, 0);
            else if (rotationDifference < -5)
                moveDirection = new Vector3(-1, 0, 0);

            XRCM.transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        transform.localRotation = Quaternion.Euler(0, 0, initialZRotation);
    }
}
