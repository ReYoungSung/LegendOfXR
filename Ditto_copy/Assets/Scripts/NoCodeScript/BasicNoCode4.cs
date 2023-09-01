using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNoCode4 : MonoBehaviour 
{
    // ��Ͽ� �Ҵ�� ���� 
    public int Score = 10;
    private bool isStart = false;
    public bool isActivated = false;

    private Renderer blockRenderer;
    private Color blueColor = Color.blue; // �Ķ������� �ٲ� ����

    private void Start()
    {
        // Renderer ������Ʈ�� �����ɴϴ�.
        blockRenderer = GetComponent<MeshRenderer>();
    }

    // ���� ����� Ȱ��ȭ�ϴ� �Լ�
    public void ActivateBlock()
    {
        isActivated = true;

        Debug.Log("���ڵ� ���� ����!! ���� ���ھ� : "+Score);
        // ����� ������ �Ķ������� �����մϴ�.
        blockRenderer.material.color = blueColor;
    }
}
