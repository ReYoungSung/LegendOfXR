using UnityEngine;

public class XRCM : MonoBehaviour
{
    public Transform target; // �ٸ� GameObject�� Transform�� �����ϱ� ���� ����
    private Vector3 lastPosition; // ���� �������� ��ġ
    private Quaternion lastRotation; // ���� �������� ȸ��

    private Vector3 FirstPosition; // ���� �������� ��ġ
    private Quaternion FirstRotation; // ���� �������� ȸ��

     public Camera firstPersonCamera;
    public Camera XRCamera;


    private void Start()
    {
        FirstPosition = transform.position;
        FirstRotation = transform.localRotation;
    } 


    private void Update()
    {
        lastPosition = transform.position;
        lastRotation = transform.localRotation;

        MovingInSceneCM();

        LockRotation();
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("PlayerHand"))
        {
            ChangeViewToXRCM();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("PlayerHand"))
        {
            ChangeViewToFirstPersonCM();
        }
    }

    public void ChangeViewToXRCM()
    {
        firstPersonCamera.enabled = false;
        XRCamera.enabled = true;
    }

    public void ChangeViewToFirstPersonCM()
    {
        firstPersonCamera.enabled = true;
        XRCamera.enabled = false;
    }

    private void MovingInSceneCM()
    {
        // ���� �������� ��ġ�� ȸ�� ���� ����
        Vector3 currentPosition = transform.position; 
        Quaternion currentRotation = transform.rotation; 

        // ��ȭ�� ���
        Vector3 positionDelta = currentPosition - lastPosition; 
        Quaternion rotationDelta = currentRotation * Quaternion.Inverse(lastRotation); 

        // �ٸ� GameObject�� ��ȭ�� ����
        target.position += positionDelta; 
        target.rotation *= rotationDelta; 

        // ���� �������� ��ġ�� ȸ�� ���� ������Ʈ
        lastPosition = currentPosition; 
        lastRotation = currentRotation; 
    }


    private void LockRotation() 
    {
        transform.position = new Vector3(lastPosition.x, FirstPosition.y, FirstPosition.z); 

        //transform.localRotation = Quaternion.Euler(FirstRotation.x, transform.localRotation.y , FirstRotation.z); 
    }
}
