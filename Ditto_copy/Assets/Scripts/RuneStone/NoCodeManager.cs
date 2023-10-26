using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCodeManager : MonoBehaviour
{
    private GameManager gameManager;

    public bool[] mission1Answers = new bool[] {false};
    public bool[] mission2Answers = new bool[] {false, false};
    public bool[] mission3Answers = new bool[] {false, false, false};

    public bool[] mission1FillBlank = new bool[] { false };
    public bool[] mission2FillBlank = new bool[] { false, false };
    public bool[] mission3FillBlank = new bool[] { false, false, false };
    public bool fullFillBlanks = false;

    //Mission1
    [HideInInspector] public bool isRepeatEvent = false;
    [SerializeField] private GameObject WatarSwordVFX;

    //Mission2
    [SerializeField] private GameObject sunLight;
    private Coroutine rotateCoroutine;
    private float rotationSpeed = 90f; 
    private float rotationDuration = 2f;
    [HideInInspector] public int TimeValue = 0;


    [HideInInspector] public bool IsPlayButtonDown = false;
    private Coroutine RuneStoneCoroutine = null; 



    private void Awake() 
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    } 


    void Start()
    {
        
    }

    
    void Update()
    {
        CheckRuneStones();
    }

    public void CheckRuneStones()
    {
        if (gameManager.CurrentMissionNum == 1)
        {
            if (mission1FillBlank[0])
            {
                fullFillBlanks = true;
            }
            else
            {
                fullFillBlanks = false;
            }

            if (mission1Answers[0] && IsPlayButtonDown)  
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }
        else if (gameManager.CurrentMissionNum == 2)
        {
            if (mission2FillBlank[0] && mission2FillBlank[1])
            {
                fullFillBlanks = true;
            }
            else
            {
                fullFillBlanks = false;
            }

            if (mission2Answers[0] && mission2Answers[1] && IsPlayButtonDown) 
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }
        else if (gameManager.CurrentMissionNum == 3)
        {
            if (mission3FillBlank[0] && mission3FillBlank[1] && mission3FillBlank[2])
            {
                fullFillBlanks = true;
            }
            else
            {
                fullFillBlanks = false;
            }

            if (mission3Answers[0] && mission3Answers[1] && mission3Answers[3] && IsPlayButtonDown)
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }  
    } 

    public void PlayRuneStone()
    {
        if(RuneStoneCoroutine == null && fullFillBlanks == true) 
        {
            if (gameManager.CurrentMissionNum == 1)
                RuneStoneCoroutine = StartCoroutine(Mission1RuneStoneFlow()); 
            else if(gameManager.CurrentMissionNum == 2)
                RuneStoneCoroutine = StartCoroutine(Mission2RuneStoneFlow()); 
            else if (gameManager.CurrentMissionNum == 3)
                RuneStoneCoroutine = StartCoroutine(Mission3RuneStoneFlow()); 
        }
            
        IsPlayButtonDown = true;  
    }

    public void StopRuneStone()
    {
        if (RuneStoneCoroutine != null)
        {
            isRepeatEvent = false; 
        }

        IsPlayButtonDown = false;  
    }

    IEnumerator Mission1RuneStoneFlow() 
    {
        yield return new WaitForSeconds(2.0f);
        
        WatarSwordVFX.SetActive(true);
        
        while (isRepeatEvent == true)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);  
        WatarSwordVFX.SetActive(false);  

        StopCoroutine(RuneStoneCoroutine);
        RuneStoneCoroutine = null;  
    }

    IEnumerator Mission2RuneStoneFlow()
    {
        yield return new WaitForSeconds(2.0f);

        RotateSunLight();

        while (isRepeatEvent == true)
        {
            RotateSunLight();
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        StopCoroutine(RuneStoneCoroutine);
        RuneStoneCoroutine = null;
    }

    public void RotateSunLight()
    {
        if (rotateCoroutine == null)
        {
            rotateCoroutine = StartCoroutine(RotateSunLightCoroutine(180f*TimeValue/12));
        }
    } 

    private IEnumerator RotateSunLightCoroutine(float targetRotation)
    {
        float rotationDuration = 5f; // 원하는 회전 시간
        float rotationTime = 0f; // 현재 회전 시간
        Quaternion startRotation = sunLight.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(startRotation.eulerAngles.x + targetRotation, 0f, 0f);

        while (rotationTime < rotationDuration)
        {
            float t = rotationTime / rotationDuration;
            sunLight.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            rotationTime += Time.deltaTime;
            yield return null;
        }

        sunLight.transform.rotation = endRotation; // 최종 회전 각도로 설정

        rotateCoroutine = null;
    }


    private IEnumerator Mission3RuneStoneFlow()
    {
        yield return new WaitForSeconds(2.0f);

        while (isRepeatEvent == true)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        
        StopCoroutine(RuneStoneCoroutine);
        RuneStoneCoroutine = null;
    }
}
