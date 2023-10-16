using UnityEngine;

public class MissionOver : MonoBehaviour
{
    private bool missionCompleted = false; // �̼� �Ϸ� ���θ� �����ϴ� ����
    private Animator animator; // �ִϸ����� ������Ʈ

    void Start()
    {
        // ĳ������ Animator ������Ʈ ��������
        animator = GameObject.Find("Wizard_anim").GetComponent<Animator>();
    }

    void Update()
    {
        // �̼� �Ϸ� ������ Ȯ���ϴ� �ڵ� (��: Ư�� Ű�� ���� ��)
        if (Input.GetKeyDown(KeyCode.Space)) // �����̽��ٸ� ������ �̼� �Ϸ�� ���� (�� �κ��� �̼� ���ǿ� �°� �����ϼ���)
        {
            // �̼� �Ϸ� ������ true�� ����
            missionCompleted = true;

            // �ִϸ������� "JumpBool" �� ���� true�� �����Ͽ� ���� �ִϸ��̼� ����
            animator.SetBool("JumpBool", true);
        }
        // �̼� �Ϸ� ��
        if (missionCompleted)
        {
            // �̼� �Ϸ� ���� �缳�� (���� False��)
            missionCompleted = false;
        }
    }
}
