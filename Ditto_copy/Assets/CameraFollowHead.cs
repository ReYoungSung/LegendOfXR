using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHead : MonoBehaviour
{
    public Transform characterHead; // 캐릭터 머리 Transform을 할당합니다.
    public float rotationSpeed = 2.0f; // 카메라 회전 속도를 조절합니다.

    private void Update()
    {
        // 캐릭터의 머리 회전 값을 가져옵니다.
        Quaternion characterHeadRotation = characterHead.rotation;

        // 카메라를 부드럽게 회전시킵니다.
        transform.rotation = Quaternion.Slerp(transform.rotation, characterHeadRotation, rotationSpeed * Time.deltaTime);
    }
}
