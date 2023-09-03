using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstpersonViewCM : MonoBehaviour
{
    public Transform RotationTarget; // �ٸ� GameObject�� Transform�� �����ϱ� ���� ����
    public Transform PositionTarget;

    private Vector3 lastPosition; // ���� �������� ��ġ
    private Quaternion lastRotation; // ���� �������� ȸ��

    private void Start()
    {
        lastPosition = PositionTarget.position;
        lastRotation = RotationTarget.localRotation;
    } 


    private void Update()
    {
        lastPosition = PositionTarget.position;
        lastRotation = RotationTarget.localRotation;

        MovingInSceneCM();
    }

    private void MovingInSceneCM()
    {
        // �ٸ� GameObject�� ��ȭ�� ����
        transform.position = lastPosition + new Vector3(0, 0.5f , 0); 
        transform.rotation = lastRotation; 
    } 
}
