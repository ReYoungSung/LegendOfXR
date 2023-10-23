using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float walkSpeed = 30f; // 걷기 속도를 조절하는 변수
    private Animator drakeAnimator; // 애니메이터 컴포넌트 변수
    private int walkCount = 0; // 걷기 애니메이션 반복 횟수를 저장하는 변수

    private void Start()
    {
        // 애니메이터 컴포넌트를 가져와 변수에 할당
        drakeAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // "walk" 애니메이션 파라미터를 true로 설정
        drakeAnimator.SetBool("walk", true);

        // 드래곤을 앞으로 이동 (Z 축 방향) - 걷기 속도로 이동
        transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);

        // walkCount를 증가시킴
        walkCount++;

        // walkCount가 10보다 크거나 같으면 애니메이션을 멈춤
        if (walkCount >= 10)
        {
            // "walk" 애니메이션 파라미터를 false로 설정하여 애니메이션 멈춤
            drakeAnimator.SetBool("walk", false);
        }
    }
}
