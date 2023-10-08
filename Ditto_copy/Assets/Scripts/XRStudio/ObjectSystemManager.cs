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
    [SerializeField] private GameObject BlackDome; 
    [SerializeField] private GameObject XRCM; 
    [SerializeField] private GameObject StudioLight; 


    [SerializeField] private Transform targetTransform;

    private bool isScaling = false;
    private bool isRotating = false;

    private float rotationSpeed = 90f; // ȸ�� �ӵ�
    private float moveSpeed = 0.5f; // �̵� �ӵ�
    private float rotationDuration = 2f; // ȸ�� ���� �ð�

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

        // CMScreen ���� ������Ʈ �ʱ� ����
        CMScreen = GameObject.Find("CMScreen");
        CMScreen.SetActive(false);

        StudioLight.SetActive(true);

        // ������ ȸ�� ���� ����
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


    // XRScreen�� ��ǥ ��ġ�� õõ�� �̵��ϴ� �޼���
    public void MoveXRScreenToTargetPosition()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToTargetPosition(targetTransform.position));
            StartCoroutine(ACtivateXRCMwithDelay());
        }
    }

    // XRScreen�� ���� ��ġ�� õõ�� �ǵ����� �޼���
    public void MoveXRScreenToOriginalPosition()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToTargetPosition(originalPosition));
            XRCM.SetActive(false);
            BlackDome.SetActive(false);
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
        BlackDome.SetActive(true); 
        XRCM.SetActive(true);
    }

    // ��� ��ü�� 180�� ȸ����Ű�� �޼���
    public void RotateObjects()
    {
        if (rotateCoroutine == null)
        {
            rotateCoroutine = StartCoroutine(RotateObjectsCoroutine(180f));
        }
    }

    // ��� ��ü�� ȸ���� �ʱ� ���·� �ǵ����� �޼���
    public void ResetObjectRotation()
    {
        if (rotateCoroutine == null)
        {
            rotateCoroutine = StartCoroutine(RotateObjectsCoroutine(180f));
        }
    }

    // ��� ��ü�� õõ�� ȸ����Ű�� Coroutine
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



    // CMScreen�� Ȱ��ȭ�ϴ� �޼���
    public void ActivateCMScreen()
    {
        activateAudioSource.Play();
        CMScreen.SetActive(true);
    }

    // CMScreen�� ��Ȱ��ȭ�ϴ� �޼���
    public void DeactivateCMScreen()
    {
        activateAudioSource.Play();
        CMScreen.SetActive(false);
    }

    // StudioLight�� Ȱ��ȭ�ϴ� �޼���
    public void ActivateStudioLight()
    {
        activateLightoSource.Play();
        StudioLight.SetActive(true);
    }

    // StudioLight�� ��Ȱ��ȭ�ϴ� �޼���
    public void DeactivateStudioLight()
    {
        activateLightoSource.Play();
        StudioLight.SetActive(false);
    }
}

