using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public float rotationSpeed = 36f; // 10�ʿ� �� ����(360��) ȸ���Ϸ��� 36�� ����մϴ�.

    void Update()
    {
        // ������Ʈ�� ȸ����ŵ�ϴ�.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
