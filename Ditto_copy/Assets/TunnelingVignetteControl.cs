using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelingVignetteControl : MonoBehaviour
{
    public GameObject tunnelingVignetteObject; // TunnelingVignette ������Ʈ

    public void ToggleTunnelingVignette()
    {
        if (tunnelingVignetteObject != null)
        {
            // TunnelingVignette�� Ȱ��ȭ ���¸� ���
            tunnelingVignetteObject.SetActive(!tunnelingVignetteObject.activeSelf);
        }
    }
}

