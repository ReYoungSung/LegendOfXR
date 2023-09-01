using UnityEngine;

public class FollowingStick : MonoBehaviour
{
    public Transform target; // 다른 GameObject의 Transform을 참조하기 위한 변수
    private Vector3 lastPosition; // 이전 프레임의 위치


    private void Update()
    {
        lastPosition = transform.localPosition;

        MovingInSceneCM();
    }


    private void MovingInSceneCM()
    {
        // 다른 GameObject에 변화값 적용
        target.localPosition = new Vector3(lastPosition.x, target.localPosition.y, target.localPosition.z); 
    }
}
