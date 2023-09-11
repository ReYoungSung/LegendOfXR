using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCMPostionController : XRGrabInteractable
{
    public GameObject XRCM;
    private Rigidbody XRCMRigidbody;

    public float moveSpeed = 20.0f; // 이동 속도 조절용 변수

    private Quaternion originRotation;

    private void Start()
    {
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();
        originRotation = XRCM.transform.localRotation;
    }

    private void Update()
    {
        // 가상 조이스틱의 로컬 Z 회전 값을 가져옵니다.
        float rotationInput = originRotation.z - this.transform.localRotation.z;

        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (rotationInput > 5)
            moveDirection = new Vector3(1, 0, 0);
        else if(rotationInput < -5)
            moveDirection = new Vector3(-1, 0, 0);

        // transform.position을 사용하여 위치를 변경합니다.
        XRCMRigidbody.MovePosition(XRCMRigidbody.position + moveDirection * moveSpeed * Time.deltaTime);

        // Check if the object is currently grabbed
        if (isSelected) 
        {
            // 여기에서 추가 동작을 수행할 수 있습니다. 
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        this.transform.localRotation = originRotation;
    }
}
