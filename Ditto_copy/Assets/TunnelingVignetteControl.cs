using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelingVignetteControl : MonoBehaviour
{
    public GameObject tunnelingVignetteObject; // TunnelingVignette 오브젝트

    public void ToggleTunnelingVignette()
    {
        if (tunnelingVignetteObject != null)
        {
            // TunnelingVignette의 활성화 상태를 토글
            tunnelingVignetteObject.SetActive(!tunnelingVignetteObject.activeSelf);
        }
    }
}

