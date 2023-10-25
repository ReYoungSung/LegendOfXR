using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VRVideoPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Camera를 할당합니다.
    public GameObject videoPlayer; // 비디오 플레이어 오브젝트를 할당합니다.

    private void Start()
    {
        // 초기에는 Virtual Camera를 비활성화합니다.
        virtualCamera.gameObject.SetActive(false);
    }

    // 영상 재생을 시작하기 위한 메소드
    public void PlayVideo()
    {
        // Virtual Camera를 활성화하여 시네마틱 영상을 보여줍니다.
        virtualCamera.gameObject.SetActive(true);

        // 비디오 플레이어를 활성화합니다.
        videoPlayer.SetActive(true);

        // 이후 영상 재생을 관리하는 코드를 추가할 수 있습니다.
    }

    // 영상 재생을 중지하기 위한 메소드
    public void StopVideo()
    {
        // Virtual Camera를 비활성화하여 시네마틱 영상을 중지합니다.
        virtualCamera.gameObject.SetActive(false);

        // 비디오 플레이어를 비활성화합니다.
        videoPlayer.SetActive(false);

        // 이후 영상 중지 및 관련 작업을 관리하는 코드를 추가할 수 있습니다.
    }
}
