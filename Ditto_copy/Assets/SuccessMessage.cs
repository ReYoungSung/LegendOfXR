using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // �� ���� �߰��մϴ�.

public class SuccessMessage : MonoBehaviour
{
    public TextMeshProUGUI successText;  // �� ���� �����մϴ�.
    public Canvas successCanvas;
    public float fadeSpeed = 1f;
    public float displayTime = 2f;

    void Start()
    {
        // ó������ Canvas�� ��Ȱ��ȭ
        successCanvas.gameObject.SetActive(false);
    }

    public void ShowSuccessMessage()
    {
        StartCoroutine(DisplaySuccessMessage());
    }

    IEnumerator DisplaySuccessMessage()
    {
        // Canvas Ȱ��ȭ
        successCanvas.gameObject.SetActive(true);

        // "����" �޽��� ����
        successText.text = "����";

        // �ؽ�Ʈ ���� ���� 0���� ����
        successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, 0);

        // �ؽ�Ʈ Fade In
        while (successText.color.a < 1)
        {
            successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, successText.color.a + (fadeSpeed * Time.deltaTime));
            yield return null;
        }

        // �޽��� ǥ��
        yield return new WaitForSeconds(displayTime);

        // �ؽ�Ʈ Fade Out
        while (successText.color.a > 0)
        {
            successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, successText.color.a - (fadeSpeed * Time.deltaTime));
            yield return null;
        }

        // Canvas ��Ȱ��ȭ
        successCanvas.gameObject.SetActive(false);
    }
}
