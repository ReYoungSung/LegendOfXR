using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

public class XRCMRotationControllerNew : MonoBehaviour
{
    public GameObject XRCM;
    private Rigidbody XRCMRigidbody;
    public float rotationSpeed = 30.0f;

    private float clickTime; // Ŭ�� ���� �ð�
    public float minClickTime = 1; // �ּ� Ŭ���ð�
    private bool isClick; // Ŭ�� ������ �Ǵ� 

    public bool isLeft = false;
    public bool isRight = false;

    private void Start()
    {
        XRCMRigidbody = XRCM.GetComponent<Rigidbody>();

    }
       
    private void Update() 
    { 
        // Ŭ�� ���̶��
        if (isClick) 
        { 
            // Ŭ���ð� ����
            clickTime += Time.deltaTime; 

            if(isLeft == true)    
                RotateLeft();
            
            if(isRight == true)
                RotateRight(); 

        } 
        // Ŭ�� ���� �ƴ϶��
        else
        { 
            // Ŭ���ð� �ʱ�ȭ
            clickTime = 0; 
        } 
    }

    public void CheckLeftButton()
    {
        isLeft = true;
    }

    public void CheckRightButton()
    {
        isRight = true;
    }
    
    // ��ư Ŭ���� �������� ��
    public void ButtonDown() 
    { 
        isClick = true; 
    } 
    
    // ��ư Ŭ���� ������ ��
    public void ButtonUp() 
    { 
        isClick = false;

        isLeft = false;
        isRight = false;
        // Ŭ�� ���� �ð��� �ּ� Ŭ���ð� �̻��̶��
        /*
        if(clickTime >= minClickTime) 
        {  
        } 
        */
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
