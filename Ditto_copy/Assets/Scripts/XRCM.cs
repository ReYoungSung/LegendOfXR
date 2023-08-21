using UnityEngine;

public class XRCM : MonoBehaviour
{
    public Transform target; // 다른 GameObject의 Transform을 참조하기 위한 변수
    private Vector3 lastPosition; // 이전 프레임의 위치
    private Quaternion lastRotation; // 이전 프레임의 회전

    private void Start()
    {
        // 시작 시 초기 위치와 회전 값을 설정
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    private void Update()
    {
        // 현재 프레임의 위치와 회전 값을 저장
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        // 변화값 계산
        Vector3 positionDelta = currentPosition - lastPosition;
        Quaternion rotationDelta = currentRotation * Quaternion.Inverse(lastRotation);

        // 다른 GameObject에 변화값 적용
        target.position += positionDelta;
        target.rotation *= rotationDelta;

        // 이전 프레임의 위치와 회전 값을 업데이트
        lastPosition = currentPosition;
        lastRotation = currentRotation;
    }
}
