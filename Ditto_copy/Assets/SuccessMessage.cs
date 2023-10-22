using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // 이 줄을 추가합니다.

public class SuccessMessage : MonoBehaviour
{
    public TextMeshProUGUI successText;  // 이 줄을 수정합니다.
    public Canvas successCanvas;
    public float fadeSpeed = 1f;
    public float displayTime = 2f;

    void Start()
    {
        // 처음에는 Canvas를 비활성화
        successCanvas.gameObject.SetActive(false);
    }

    public void ShowSuccessMessage()
    {
        StartCoroutine(DisplaySuccessMessage());
    }

    IEnumerator DisplaySuccessMessage()
    {
        // Canvas 활성화
        successCanvas.gameObject.SetActive(true);

        // "성공" 메시지 설정
        successText.text = "성공";

        // 텍스트 알파 값을 0으로 설정
        successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, 0);

        // 텍스트 Fade In
        while (successText.color.a < 1)
        {
            successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, successText.color.a + (fadeSpeed * Time.deltaTime));
            yield return null;
        }

        // 메시지 표시
        yield return new WaitForSeconds(displayTime);

        // 텍스트 Fade Out
        while (successText.color.a > 0)
        {
            successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, successText.color.a - (fadeSpeed * Time.deltaTime));
            yield return null;
        }

        // Canvas 비활성화
        successCanvas.gameObject.SetActive(false);
    }
}
