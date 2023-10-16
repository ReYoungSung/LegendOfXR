using UnityEngine;

public class MissionOver : MonoBehaviour
{
    private bool missionCompleted = false; // 미션 완료 여부를 저장하는 변수
    private Animator animator; // 애니메이터 컴포넌트

    void Start()
    {
        // 캐릭터의 Animator 컴포넌트 가져오기
        animator = GameObject.Find("Wizard_anim").GetComponent<Animator>();
    }

    void Update()
    {
        // 미션 완료 조건을 확인하는 코드 (예: 특정 키를 누를 때)
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바를 누르면 미션 완료로 설정 (이 부분을 미션 조건에 맞게 수정하세요)
        {
            // 미션 완료 변수를 true로 설정
            missionCompleted = true;

            // 애니메이터의 "JumpBool" 불 값을 true로 설정하여 점프 애니메이션 실행
            animator.SetBool("JumpBool", true);
        }
        // 미션 완료 시
        if (missionCompleted)
        {
            // 미션 완료 변수 재설정 (원래 False로)
            missionCompleted = false;
        }
    }
}
