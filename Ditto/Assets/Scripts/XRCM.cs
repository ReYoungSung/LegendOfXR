using UnityEngine;

public class XRCM : MonoBehaviour
{
    public Transform target; // �ٸ� GameObject�� Transform�� �����ϱ� ���� ����
    private Vector3 lastPosition; // ���� �������� ��ġ
    private Quaternion lastRotation; // ���� �������� ȸ��

    private void Start()
    {
        // ���� �� �ʱ� ��ġ�� ȸ�� ���� ����
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    private void Update()
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
}
