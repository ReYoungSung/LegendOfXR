using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCodeManager : MonoBehaviour
{
    private GameManager gameManager;

    public bool[] mission1Answers = new bool[] {false};
    public bool[] mission2Answers = new bool[] {false, false};
    public bool[] mission3Answers = new bool[] {false, false, false, false, false};

    public bool[] mission1FillBlank = new bool[] { false };
    public bool[] mission2FillBlank = new bool[] { false, false };
    public bool[] mission3FillBlank = new bool[] { false, false, false, false, false};
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
    private Quaternion originSunLightRotation;

    //Mission3
    [SerializeField] private GameObject Metheo;
    [SerializeField] private GameObject Shield; 


    [HideInInspector] public bool IsPlayButtonDown = false;
    private Coroutine RuneStoneCoroutine = null; 



    private void Awake() 
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    } 


    void Start()
    {
        originSunLightRotation = sunLight.transform.localRotation;
    }

    
    void Update()
    {
        CheckRuneStones();
    }

    public void CheckRuneStones()
    {
        if (gameManager.CurrentMissionNum == 1)
        {
            if (ArrayIsAllTrue(mission1FillBlank))
            {
                fullFillBlanks = true;
            }
            else
            {
                fullFillBlanks = false;
            }

            if (ArrayIsAllTrue(mission1Answers))  
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
            if (ArrayIsAllTrue(mission2FillBlank))
            {
                fullFillBlanks = true;
            }
            else
            {
                fullFillBlanks = false;
            }

            if (ArrayIsAllTrue(mission2Answers)) 
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
            if (ArrayIsAllTrue(mission3FillBlank))
            {
                fullFillBlanks = true;
            }
            else
            {
                fullFillBlanks = false;
            }

            if (ArrayIsAllTrue(mission3Answers))
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }  
    } 

    private bool ArrayIsAllTrue(bool[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            if(array[i] == false)
            {
                return false;
            }
        }
        return true; 
    }


    public void PlayRuneStone()
    {
        if(RuneStoneCoroutine == null && fullFillBlanks == true) 
        {
            if (gameManager.CurrentMissionNum == 1)
                RuneStoneCoroutine = StartCoroutine(Mission1RuneStoneFlow());
            else if (gameManager.CurrentMissionNum == 2)
                RuneStoneCoroutine = StartCoroutine(Mission2RuneStoneFlow());
            else if (gameManager.CurrentMissionNum == 3)
            {
                RuneStoneCoroutine = StartCoroutine(Mission3RuneStoneFlow1());
                RuneStoneCoroutine = StartCoroutine(Mission3RuneStoneFlow2());
            }
        }
            
        IsPlayButtonDown = true;  
    }

    public void StopRuneStone()
    {
        if (RuneStoneCoroutine != null)
        {
            isRepeatEvent = false;
            sunLight.transform.localRotation = originSunLightRotation;
        }

        IsPlayButtonDown = false;  
    }

    //Mission1
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

    //Mission2 
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

    //Mission3
    private IEnumerator Mission3RuneStoneFlow1()
    {
        yield return new WaitForSeconds(2.0f);

        Metheo.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Metheo.transform.GetChild(0).gameObject.SetActive(true);

        while (isRepeatEvent == true)
        {
            yield return null;
        }

        Metheo.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        Metheo.SetActive(false);

        yield return new WaitForSeconds(1.0f);  
        
        StopCoroutine(RuneStoneCoroutine);   
        RuneStoneCoroutine = null;  
    }

    private IEnumerator Mission3RuneStoneFlow2()
    {
        yield return new WaitForSeconds(2.0f);

        Shield.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Shield.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Shield.transform.GetChild(2).gameObject.SetActive(true);

        while (isRepeatEvent == true)  
        {
            yield return null; 
        }

        Shield.transform.GetChild(2).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Shield.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Shield.transform.GetChild(0).gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        StopCoroutine(RuneStoneCoroutine);
        RuneStoneCoroutine = null;
    }
}
