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

    [SerializeField] private GameObject[] NeonLightLineObjects;
    [SerializeField] private GameObject[] RuneStoneObjects;
    private GameObject[] RuneStonesOriginTransform; 

    [SerializeField] private GameObject avatar1;
    [SerializeField] private GameObject avatar2;
    [SerializeField] public GameObject avatar3;

    private Transform originAvatar1Transform;
    private Transform originAvatar2Transform;
    private Transform originAvatar3Transform;

    [HideInInspector] public bool isActiveXRScreen = false;
    [HideInInspector] public bool isActiveBookshelfs = false;
    [HideInInspector] public bool isActiveCMScreen = false;
    [HideInInspector] public bool isActiveStudioLight = true;
    [HideInInspector] public bool isActiveFullSetting = false;

    private float rotationSpeed = 90f; // ȸ�� �ӵ� 
    private float moveSpeed = 0.5f; // �̵� �ӵ� 
    private float rotationDuration = 2f; // ȸ�� ���� �ð� 
 
    private Coroutine moveCoroutine;
    private Coroutine rotateCoroutine;
    private Coroutine scaleCoroutine;

    private SoundManager soundManager;    
    private XRScreenManager xrScreenManager;





    void Start()
    {
        soundManager = this.GetComponent<SoundManager>();
        xrScreenManager = this.GetComponent<XRScreenManager>();
        
        originalPosition = XRScreenTransform.position;

        // ������ ȸ�� ���� ����
        originalRotation = objectsToRotate[0].transform.rotation;

        originAvatar1Transform = avatar1.transform;
        originAvatar2Transform = avatar2.transform;
        originAvatar3Transform = avatar3.transform;
        SaveRuneStonesOriginTransform();
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
            RotateBookshelfs();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ResetBookshelfsRotation();
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

        if (Input.GetKey(KeyCode.T))
        {
            ActiveXRSetting();
        }
        else if (Input.GetKey(KeyCode.G))
        {
            DeActiveXRSetting();
        }

        if(isActiveXRScreen == true
           && isActiveBookshelfs == true
           && isActiveCMScreen == true
           && isActiveStudioLight == false)
        {
            isActiveFullSetting = true;
        }
        else
        {
            isActiveFullSetting = false;
        }
    }

    public void ActiveXRSetting()
    {
        MoveXRScreenToTargetPosition(); 
        RotateBookshelfs(); 
        DeactivateStudioLight(); 
        ActivateCMScreen(); 
    }

    public void DeActiveXRSetting()
    {
        MoveXRScreenToOriginalPosition();  
        ResetBookshelfsRotation();  
        ActivateStudioLight();  
        DeactivateCMScreen();  
    }

    // XRScreen�� ��ǥ ��ġ�� õõ�� �̵��ϴ� �޼���
    public void MoveXRScreenToTargetPosition()
    {
        if (!isActiveXRScreen)
        {
            if (moveCoroutine == null)
            {
                moveCoroutine = StartCoroutine(MoveToTargetPosition(targetTransform.position));
                StartCoroutine(ACtivateXRCMwithDelay());
                // Set isActive to true since XRScreen is active
                isActiveXRScreen = true;
            }
        }
    }

    // XRScreen�� ���� ��ġ�� õõ�� �ǵ����� �޼���
    public void MoveXRScreenToOriginalPosition()
    {
        if (isActiveXRScreen)
        {
            soundManager.StopAllBGM();
            if (moveCoroutine == null)
            {
                moveCoroutine = StartCoroutine(MoveToTargetPosition(originalPosition));
                XRCM.SetActive(false);
                BlackDome.SetActive(false);
                // Set isActive to false since XRScreen is deactivated
                isActiveXRScreen = false;
            }
        }
    }

    private IEnumerator MoveToTargetPosition(Vector3 target)
    {
        float journeyLength = Vector3.Distance(XRScreenTransform.position, target);
        float startTime = Time.time;

        soundManager.PlaySFX("XRScreenSFX");
        while (XRScreenTransform.position != target)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            XRScreenTransform.position = Vector3.Lerp(XRScreenTransform.position, target, fractionOfJourney);

            yield return null;
        }
        soundManager.StopSFX("XRScreenSFX");
        moveCoroutine = null;
    }

    private IEnumerator ACtivateXRCMwithDelay()
    {
        yield return new WaitForSeconds(3);
        BlackDome.SetActive(true); 
        XRCM.SetActive(true);
    }

    // ��� ��ü�� 180�� ȸ����Ű�� �޼���
    public void RotateBookshelfs()   
    {
        if (!isActiveBookshelfs)
        {
            if (rotateCoroutine == null)
            {
                rotateCoroutine = StartCoroutine(RotateBookshelfsCoroutine(180f));
                // Set isActive to true since bookshelves are active
                isActiveBookshelfs = true;
            }
        }
    }

    // ��� ��ü�� ȸ���� �ʱ� ���·� �ǵ����� �޼���
    public void ResetBookshelfsRotation()   
    {
        if (isActiveBookshelfs)
        {
            if (rotateCoroutine == null)
            {
                rotateCoroutine = StartCoroutine(RotateBookshelfsCoroutine(180f)); 
                // Set isActive to false since bookshelves are deactivated
                isActiveBookshelfs = false;
            }
        }
    }


    // ��� ��ü�� õõ�� ȸ����Ű�� Coroutine
    private IEnumerator RotateBookshelfsCoroutine(float targetRotation)
    {
        float rotationTime = 0f;
        Quaternion[] currentRotations = new Quaternion[objectsToRotate.Length];

        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            currentRotations[i] = objectsToRotate[i].transform.rotation;
        }

        soundManager.PlaySFX("BookshelfSFX"); 
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
        soundManager.StopSFX("BookshelfSFX"); 

        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            objectsToRotate[i].transform.rotation = Quaternion.Euler(0f, currentRotations[i].eulerAngles.y + targetRotation, 0f);
        }

        rotateCoroutine = null;
    } 

    // CMScreen�� Ȱ��ȭ�ϴ� �޼��� 
    public void ActivateCMScreen()   
    {
        if (CMScreen.activeSelf == false)
        {
            soundManager.PlaySFX("CMScreenSFX");
            CMScreen.SetActive(true);
            // Set isActive to true since CMScreen is active
            isActiveCMScreen = true;
        }
    }
        
    // CMScreen�� ��Ȱ��ȭ�ϴ� �޼���
    public void DeactivateCMScreen()   
    {
        if (CMScreen.activeSelf == true)
        {
            soundManager.PlaySFX("CMScreenSFX");
            CMScreen.SetActive(false);
            // Set isActive to false since CMScreen is deactivated
            isActiveCMScreen = false;
        }
    }

    // StudioLight�� Ȱ��ȭ�ϴ� �޼���
    public void ActivateStudioLight()  
    {
        if (StudioLight.activeSelf == false)
        {
            StudioLight.SetActive(true);
            DeActivateNeonLightLine();
            // Set isActive to true since StudioLight is active
            isActiveStudioLight = true;
        }
    }

    // StudioLight�� ��Ȱ��ȭ�ϴ� �޼���
    public void DeactivateStudioLight()  
    {
        if (StudioLight.activeSelf == true) 
        {
            StudioLight.SetActive(false);
            ActivateNeonLightLine();
            // Set isActive to false since StudioLight is deactivated
            isActiveStudioLight = false; 
        }
    }

    public void ActivateNeonLightLine()
    {
        for (int i = 0; i < NeonLightLineObjects.Length; i++)
        {
            NeonLightLineObjects[i].SetActive(true);
        }
    }

    public void DeActivateNeonLightLine()
    {
        for (int i = 0; i < NeonLightLineObjects.Length; i++)
        {
            NeonLightLineObjects[i].SetActive(false);
        }
    }

    public void SaveRuneStonesOriginTransform()
    {
        RuneStonesOriginTransform = new GameObject[RuneStoneObjects.Length]; 

        for (int i = 0; i < RuneStoneObjects.Length; i++)
        {
            if (i < RuneStonesOriginTransform.Length)
            {
                GameObject runeObject = RuneStoneObjects[i];
                GameObject originTransform = RuneStonesOriginTransform[i];

                if (runeObject != null && originTransform != null)
                {
                    originTransform.transform.position = runeObject.transform.position;
                    originTransform.transform.rotation = runeObject.transform.rotation;
                }
            }
        }
    }

    public void returnObjectsToOriginSpace() 
    {
        avatar1.transform.position = originAvatar1Transform.position;
        avatar2.transform.position = originAvatar2Transform.position; 
        avatar3.transform.position = originAvatar3Transform.position;
        avatar1.transform.localRotation = originAvatar1Transform.localRotation;
        avatar2.transform.localRotation = originAvatar2Transform.localRotation;
        avatar3.transform.localRotation = originAvatar3Transform.localRotation;

        for (int i = 0; i < RuneStoneObjects.Length; i++)
        {
            if (i < RuneStonesOriginTransform.Length)
            {
                GameObject runeObject = RuneStoneObjects[i];
                GameObject originTransform = RuneStonesOriginTransform[i];

                if (runeObject != null && originTransform != null)
                {
                    runeObject.transform.position = originTransform.transform.position;
                    runeObject.transform.rotation = originTransform.transform.rotation;
                }
            }
        }
    }
}

