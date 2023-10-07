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
    [SerializeField] private GameObject XRCM;
    [SerializeField] private GameObject StudioLight;


    [SerializeField] private Transform targetTransform;

    private bool isScaling = false;
    private bool isRotating = false;

    private float rotationSpeed = 90f; // 회전 속도
    private float moveSpeed = 0.5f; // 이동 속도
    private float rotationDuration = 2f; // 회전 지속 시간

    private Coroutine moveCoroutine;
    private Coroutine rotateCoroutine;
    private Coroutine scaleCoroutine;

    [SerializeField] private AudioSource moveAudioSource;
    [SerializeField] private AudioSource rotateAudioSource;
    [SerializeField] private AudioSource activateAudioSource;
    [SerializeField] private AudioSource activateLightoSource;

    void Start()
    {
        originalPosition = XRScreenTransform.position;

        // CMScreen 게임 오브젝트 초기 설정
        CMScreen = GameObject.Find("CMScreen");
        CMScreen.SetActive(false);

        StudioLight.SetActive(false);

        // 원래의 회전 상태 저장
        originalRotation = objectsToRotate[0].transform.rotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            MoveXRScreenToTargetPosition();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveXRScreenToOriginalPosition();
        }

        if (Input.GetKey(KeyCode.W))
        {
            RotateObjects();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ResetObjectRotation();
        }

        if (Input.GetKey(KeyCode.E))
        {
            ActivateCMScreen();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            DeactivateCMScreen();
        }

        if (Input.GetKey(KeyCode.R))
        {
            ActivateStudioLight();
        }
        else if (Input.GetKey(KeyCode.F))
        {
            DeactivateStudioLight();
        }
    }


    // XRScreen을 목표 위치로 천천히 이동하는 메서드
    public void MoveXRScreenToTargetPosition()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToTargetPosition(targetTransform.position));
            StartCoroutine(ACtivateXRCMwithDelay());
        }
    }

    // XRScreen을 원래 위치로 천천히 되돌리는 메서드
    public void MoveXRScreenToOriginalPosition()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToTargetPosition(originalPosition));
            XRCM.SetActive(false);
        }
    }

    private IEnumerator MoveToTargetPosition(Vector3 target)
    {
        float journeyLength = Vector3.Distance(XRScreenTransform.position, target);
        float startTime = Time.time;

        moveAudioSource.Play();
        while (XRScreenTransform.position != target)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            XRScreenTransform.position = Vector3.Lerp(XRScreenTransform.position, target, fractionOfJourney);

            yield return null;
        }
        moveAudioSource.Stop();
        moveCoroutine = null;
    }

    private IEnumerator ACtivateXRCMwithDelay()
    {
        yield return new WaitForSeconds(3);
        XRCM.SetActive(true);
    }

    // 모든 객체를 180도 회전시키는 메서드
    public void RotateObjects()
    {
        if (rotateCoroutine == null)
        {
            rotateCoroutine = StartCoroutine(RotateObjectsCoroutine(180f));
        }
    }

    // 모든 객체의 회전을 초기 상태로 되돌리는 메서드
    public void ResetObjectRotation()
    {
        if (rotateCoroutine == null)
        {
            rotateCoroutine = StartCoroutine(RotateObjectsCoroutine(180f));
        }
    }

    // 모든 객체를 천천히 회전시키는 Coroutine
    private IEnumerator RotateObjectsCoroutine(float targetRotation)
    {
        float rotationTime = 0f;
        Quaternion[] currentRotations = new Quaternion[objectsToRotate.Length];

        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            currentRotations[i] = objectsToRotate[i].transform.rotation;
        }

        rotateAudioSource.Play();
        while (rotationTime < rotationDuration)
        {
            float t = rotationTime / rotationDuration;
            for (int i = 0; i < objectsToRotate.Length; i++)
            {
                objectsToRotate[i].transform.rotation = Quaternion.Slerp(currentRotations[i], Quaternion.Euler(0f, currentRotations[i].eulerAngles.y + targetRotation, 0f), t);
            }
            rotationTime += Time.deltaTime;
            yield return null;
        }
        rotateAudioSource.Stop();

        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            objectsToRotate[i].transform.rotation = Quaternion.Euler(0f, currentRotations[i].eulerAngles.y + targetRotation, 0f);
        }

        isRotating = false;

        rotateCoroutine = null;
    }



    // CMScreen을 활성화하는 메서드
    public void ActivateCMScreen()
    {
        activateAudioSource.Play();
        CMScreen.SetActive(true);
    }

    // CMScreen을 비활성화하는 메서드
    public void DeactivateCMScreen()
    {
        activateAudioSource.Play();
        CMScreen.SetActive(false);
    }

    // StudioLight를 활성화하는 메서드
    public void ActivateStudioLight()
    {
        activateLightoSource.Play();
        StudioLight.SetActive(true);
    }

    // StudioLight를 비활성화하는 메서드
    public void DeactivateStudioLight()
    {
        activateLightoSource.Play();
        StudioLight.SetActive(false);
    }
}

