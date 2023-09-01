using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public float rotationSpeed = 36f; // 10초에 한 바퀴(360도) 회전하려면 36을 사용합니다.

    void Update()
    {
        // 오브젝트를 회전시킵니다.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
