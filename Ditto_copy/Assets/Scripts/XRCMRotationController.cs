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

    public ButtonType buttonType = ButtonType.Left; // ���� ��ư�� ��Ÿ���� Enum ����
    
    public float rotationSpeed = 30.0f; // ȸ�� �ӵ�

    private bool isLeftButtonPressed = false; // ���� ��ư�� ���ȴ��� ����
    private bool isRightButtonPressed = false; // ������ ��ư�� ���ȴ��� ����

    private void Start()
    {
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
            SetButtonState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
            SetButtonState(false);
    }

    private void Update()
    {
        // ���� ��ư�� ������ ��ư�� ������ ���� ������ �����մϴ�.
        if (isLeftButtonPressed)
        {
            // ���� ��ư ���� ����
            RotateLeft();
        }
        else if (isRightButtonPressed)
        {
            // ������ ��ư ���� ����
            RotateRight();
        }
    }

    // ���� ��ư�� ������ ��ư�� �հ� �������� �� ȣ���� �޼���
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

    // ���� ��ư�� ������ �� ȣ���� �޼���
    void RotateLeft()
    {
        // �������� ȸ���ϴ� �ڵ带 ���⿡ �ۼ�
        XRCM.transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
    }

    // ������ ��ư�� ������ �� ȣ���� �޼���
    void RotateRight()
    {
        // ���������� ȸ���ϴ� �ڵ带 ���⿡ �ۼ�
        XRCM.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
