using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCMPostionController : XRGrabInteractable
{
    public GameObject XRCM;
    private Rigidbody XRCMRigidbody;

    public float moveSpeed = 20.0f; // �̵� �ӵ� ������ ����

    private Quaternion originRotation;

    private void Start()
    {
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();
        originRotation = XRCM.transform.localRotation;
    }

    private void Update()
    {
        // ���⿡�� �߰� ������ ������ �� �ֽ��ϴ�. 
        // ���� ���̽�ƽ�� ���� Z ȸ�� ���� �����ɴϴ�.
        float rotationInput = originRotation.z - this.transform.localRotation.z;

            Vector3 moveDirection = new Vector3(0, 0, 0);

            if (rotationInput > 5)
                moveDirection = new Vector3(1, 0, 0);
            else if(rotationInput < -5)
                moveDirection = new Vector3(-1, 0, 0);
            
            // transform.position�� ����Ͽ� ��ġ�� �����մϴ�.
            XRCMRigidbody.MovePosition(XRCMRigidbody.position + moveDirection * moveSpeed * Time.deltaTime);

        // Check if the object is currently grabbed
        if (isSelected) 
        {
            
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        this.transform.localRotation = originRotation;
    }
}
