using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNoCode3 : MonoBehaviour 
{
    // ��Ͽ� �Ҵ�� ���� 
    public int Score = 10;
    private bool isStart = false;
    public bool isActivated = false;

    private Renderer blockRenderer;
    private Color blueColor = Color.blue; // �Ķ������� �ٲ� ����
    private Color redColor = Color.red;

    private float MaxRayDistance = 3f;
    private RaycastHit hit;

    private void Start()
    {
        // Renderer ������Ʈ�� �����ɴϴ�.
        blockRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        activeNoCoding();
    } 

    private void activeNoCoding()
    {
        // ����� ������ �������� ray�� �߻��մϴ�.
        Ray ray = new Ray(transform.position, -transform.forward);

        if (isStart || !isActivated) 
        {
            // Visualize the ray in the Scene view
            Debug.DrawRay(ray.origin, ray.direction * MaxRayDistance, Color.red);
            return;
        }
        else if (Physics.Raycast(ray, out hit, MaxRayDistance) && !hit.collider.CompareTag("Block4"))
        {
            ErrorBlock(); 
            return; 
        }

        // Check if the raycast hit something before accessing the hit variable
        if (hit.collider != null)
        {        
            // �浹 �� �÷��׸� ����
            isStart = true; 
        
            // ����� Ȱ��ȭ�ϰ� ������ �߰�
            ActivateBlock();
            hit.transform.GetComponent<BasicNoCode4>().Score += Score;
            hit.transform.GetComponent<BasicNoCode4>().ActivateBlock();
        }
    }

    // ���� ����� Ȱ��ȭ�ϴ� �Լ�
    public void ActivateBlock()
    {
        isActivated = true;

        // ����� ������ �Ķ������� �����մϴ�.
        blockRenderer.material.color = blueColor;
    }

    public void ErrorBlock()
    {
        Debug.Log("���ڵ� ���� ����!! �ٽ� �õ��غ�����..!!");
        hit.transform.GetComponent<MeshRenderer>().material.color = redColor;
    }
}
