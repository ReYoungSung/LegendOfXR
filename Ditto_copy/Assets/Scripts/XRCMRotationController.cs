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

    public ButtonType buttonType = ButtonType.Left; // 왼쪽 버튼을 나타내는 Enum 변수
    
    public float rotationSpeed = 30.0f; // 회전 속도

    private bool isLeftButtonPressed = false; // 왼쪽 버튼이 눌렸는지 여부
    private bool isRightButtonPressed = false; // 오른쪽 버튼이 눌렸는지 여부

    private void Start()
    {
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SetButtonState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        SetButtonState(false);
    }

    private void Update()
    {
        // 왼쪽 버튼과 오른쪽 버튼이 눌렸을 때의 동작을 수행합니다.
        if (isLeftButtonPressed)
        {
            // 왼쪽 버튼 동작 수행
            RotateLeft();
        }
        else if (isRightButtonPressed)
        {
            // 오른쪽 버튼 동작 수행
            RotateRight();
        }
    }

    // 왼쪽 버튼과 오른쪽 버튼이 손과 접촉했을 때 호출할 메서드
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

    // 왼쪽 버튼을 눌렀을 때 호출할 메서드
    void RotateLeft()
    {
        // 왼쪽으로 회전하는 코드를 여기에 작성
        XRCM.transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
    }

    // 오른쪽 버튼을 눌렀을 때 호출할 메서드
    void RotateRight()
    {
        // 오른쪽으로 회전하는 코드를 여기에 작성
        XRCM.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
