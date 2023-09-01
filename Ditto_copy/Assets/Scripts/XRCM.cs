using UnityEngine;

public class XRCM : MonoBehaviour
{
    public Transform target; // 다른 GameObject의 Transform을 참조하기 위한 변수
    private Vector3 lastPosition; // 이전 프레임의 위치
    private Quaternion lastRotation; // 이전 프레임의 회전

    private Vector3 FirstPosition; // 이전 프레임의 위치
    private Quaternion FirstRotation; // 이전 프레임의 회전


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
        // 현재 프레임의 위치와 회전 값을 저장
        Vector3 currentPosition = transform.position; 
        Quaternion currentRotation = transform.localRotation; 

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


    private void LockTransform() 
    {
        transform.position = new Vector3(lastPosition.x, FirstPosition.y, FirstPosition.z); 

        //transform.localRotation = Quaternion.Euler(FirstRotation.x, transform.localRotation.y , FirstRotation.z); 
    }
}
