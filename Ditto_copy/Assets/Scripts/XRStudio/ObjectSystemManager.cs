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

    private float scaleSpeed = 0.5f; // 크기 변환 속도
    private float rotationSpeed = 90f; // 회전 속도
    private float moveSpeed = 0.5f; // 이동 속도
    private float scaleDuration = 2f; // 스케일링 지속 시간
    private float rotationDuration = 2f; // 회전 지속 시간

    public bool test1 = false;
    public bool test2 = false;
    public bool test3 = false;
    public bool test4 = false;

    void Start()
    {
        originalPosition = XRScreenTransform.position;

        // CMScreen 게임 오브젝트 초기 설정
        CMScreen = GameObject.Find("CMScreen");
        originalScale = CMScreen.transform.localScale;
        CMScreen.SetActive(false);

        StudioLight.SetActive(false);

        // 원래의 회전 상태 저장
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

    // XRScreen을 목표 위치로 천천히 이동하는 메서드
    public void MoveXRScreenToTargetPosition()
    {
        StartCoroutine(MoveToTargetPosition(targetTransform.position));
    }

    // XRScreen을 원래 위치로 천천히 되돌리는 메서드
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

    // 모든 객체를 180도 회전시키는 메서드
    public void RotateObjects()
    {
        StartCoroutine(RotateObjectsCoroutine(180f));
    }

    // 모든 객체의 회전을 초기 상태로 되돌리는 메서드
    public void ResetObjectRotation()
    {
        StartCoroutine(RotateObjectsCoroutine(0f));
    }

    // 모든 객체를 천천히 회전시키는 Coroutine
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

    // CMScreen 확대 및 활성화 메서드
    public void ScaleUpCMScreen()
    {
        StartCoroutine(ScaleCMScreen(Vector3.one * 3f));
    }

    // CMScreen 축소 및 비활성화 메서드
    public void ScaleDownCMScreen()
    {
        StartCoroutine(ScaleCMScreen(Vector3.one * 0.5f)); 
    }

    // CMScreen을 천천히 스케일링하는 Coroutine
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

    // StudioLight를 활성화하는 메서드
    public void ActivateStudioLight()
    {
        StudioLight.SetActive(true);
    }

    // StudioLight를 비활성화하는 메서드
    public void DeactivateStudioLight()
    {
        StudioLight.SetActive(false);
    }
}

