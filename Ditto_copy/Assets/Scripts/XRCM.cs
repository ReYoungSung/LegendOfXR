using UnityEngine;

public class XRCM : MonoBehaviour
{
    public Transform target; // �ٸ� GameObject�� Transform�� �����ϱ� ���� ����
    private Vector3 lastPosition; // ���� �������� ��ġ
    private Quaternion lastRotation; // ���� �������� ȸ��

    private Vector3 FirstPosition; // ���� �������� ��ġ
    private Quaternion FirstRotation; // ���� �������� ȸ��


    private void Start()
    {
        FirstPosition = transform.position;
        FirstRotation = transform.rotation;

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    } 


    private void Update()
    {
        MovingInSceneCM();

        LockTransform();
    }

    private void MovingInSceneCM()
    {
        // ���� �������� ��ġ�� ȸ�� ���� ����
        Vector3 currentPosition = transform.position; 
        Quaternion currentRotation = transform.localRotation; 

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


    private void LockTransform() 
    {
        transform.position = new Vector3(lastPosition.x, FirstPosition.y, FirstPosition.z); 

        //transform.localRotation = Quaternion.Euler(FirstRotation.x, transform.localRotation.y , FirstRotation.z); 
    }
}
