using UnityEngine;

public class FollowingStick : MonoBehaviour
{
    public Transform target; // �ٸ� GameObject�� Transform�� �����ϱ� ���� ����
    private Vector3 lastPosition; // ���� �������� ��ġ


    private void Update()
    {
        lastPosition = transform.localPosition;

        MovingInSceneCM();
    }


    private void MovingInSceneCM()
    {
        // �ٸ� GameObject�� ��ȭ�� ����
        target.localPosition = new Vector3(lastPosition.x, target.localPosition.y, target.localPosition.z); 
    }
}
