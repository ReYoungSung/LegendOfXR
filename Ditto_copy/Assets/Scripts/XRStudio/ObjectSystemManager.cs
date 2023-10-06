using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSystemManager : MonoBehaviour
{
    [SerializeField] private Transform XRScreenTransform;
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    [SerializeField] private GameObject[] objectsToRotate;
    [SerializeField] private GameObject CMScreen;
    [SerializeField] private GameObject StudioLight;

    [SerializeField] private Transform targetTransform;
    private Vector3 originalScale;

    private bool isScaling = false;
    private bool isRotating = false;

    private float scaleSpeed = 0.5f; // ũ�� ��ȯ �ӵ�
    private float rotationSpeed = 90f; // ȸ�� �ӵ�
    private float moveSpeed = 0.5f; // �̵� �ӵ�
    private float scaleDuration = 2f; // �����ϸ� ���� �ð�
    private float rotationDuration = 2f; // ȸ�� ���� �ð�

    public bool test1 = false;
    public bool test2 = false;
    public bool test3 = false;
    public bool test4 = false;

    void Start()
    {
        originalPosition = XRScreenTransform.position;

        // CMScreen ���� ������Ʈ �ʱ� ����
        CMScreen = GameObject.Find("CMScreen");
        originalScale = CMScreen.transform.localScale;
        CMScreen.SetActive(false);

        StudioLight.SetActive(false);

        // ������ ȸ�� ���� ����
        originalRotation = objectsToRotate[0].transform.rotation;
    }

    void Update()
    {
        if(test1)
        {
            MoveXRScreenToTargetPosition();
        }
        else
        {
            MoveXRScreenToOriginalPosition();
        }

        if (test2)
        {
            RotateObjects();
        }
        else
        {
            ResetObjectRotation();
        }

        if (test3)
        {
            ScaleUpCMScreen();
        }
        else
        {
            ScaleDownCMScreen();
        }

        if (test4)
        {
            ActivateStudioLight();
        }
        else
        {
            DeactivateStudioLight(); 
        }
    }

    // XRScreen�� ��ǥ ��ġ�� õõ�� �̵��ϴ� �޼���
    public void MoveXRScreenToTargetPosition()
    {
        StartCoroutine(MoveToTargetPosition(targetTransform.position));
    }

    // XRScreen�� ���� ��ġ�� õõ�� �ǵ����� �޼���
    public void MoveXRScreenToOriginalPosition()
    {
        StartCoroutine(MoveToTargetPosition(originalPosition));
    }

    private IEnumerator MoveToTargetPosition(Vector3 target)
    {
        float journeyLength = Vector3.Distance(XRScreenTransform.position, target);
        float startTime = Time.time;

        while (XRScreenTransform.position != target)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            XRScreenTransform.position = Vector3.Lerp(XRScreenTransform.position, target, fractionOfJourney);

            yield return null;
        }
    }

    // ��� ��ü�� 180�� ȸ����Ű�� �޼���
    public void RotateObjects()
    {
        StartCoroutine(RotateObjectsCoroutine(180f));
    }

    // ��� ��ü�� ȸ���� �ʱ� ���·� �ǵ����� �޼���
    public void ResetObjectRotation()
    {
        StartCoroutine(RotateObjectsCoroutine(0f));
    }

    // ��� ��ü�� õõ�� ȸ����Ű�� Coroutine
    private IEnumerator RotateObjectsCoroutine(float targetRotation)
    {
        float rotationTime = 0f;
        float startRotation = objectsToRotate[0].transform.rotation.eulerAngles.y;

        while (rotationTime < rotationDuration)
        {
            float newRotation = Mathf.LerpAngle(startRotation, targetRotation, rotationTime / rotationDuration);
            foreach (var obj in objectsToRotate)
            {
                obj.transform.rotation = Quaternion.Euler(0f, newRotation, 0f); 
            }
            rotationTime += Time.deltaTime;
            yield return null;
        }

        foreach (var obj in objectsToRotate)
        {
            obj.transform.rotation = Quaternion.Euler(0f, targetRotation, 0f); 
        }

        isRotating = false;
    }

    // CMScreen Ȯ�� �� Ȱ��ȭ �޼���
    public void ScaleUpCMScreen()
    {
        StartCoroutine(ScaleCMScreen(Vector3.one * 3f));
    }

    // CMScreen ��� �� ��Ȱ��ȭ �޼���
    public void ScaleDownCMScreen()
    {
        StartCoroutine(ScaleCMScreen(Vector3.one * 0.5f)); 
    }

    // CMScreen�� õõ�� �����ϸ��ϴ� Coroutine
    private IEnumerator ScaleCMScreen(Vector3 targetScale)
    {
        float scaleTime = 0f;
        Vector3 startScale = CMScreen.transform.localScale;

        while (scaleTime < scaleDuration)
        {
            CMScreen.transform.localScale = Vector3.Lerp(startScale, targetScale, scaleTime / scaleDuration);
            scaleTime += Time.deltaTime;
            yield return null;
        }

        CMScreen.transform.localScale = targetScale;

        if (targetScale == Vector3.one * 3f)
        {
            isScaling = false;
        }
        else
        {
            isScaling = false;
            CMScreen.SetActive(false);
        }
    }

    // StudioLight�� Ȱ��ȭ�ϴ� �޼���
    public void ActivateStudioLight()
    {
        StudioLight.SetActive(true);
    }

    // StudioLight�� ��Ȱ��ȭ�ϴ� �޼���
    public void DeactivateStudioLight()
    {
        StudioLight.SetActive(false);
    }
}

