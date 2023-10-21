using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isClearMission1 = false;  
    private bool isClearMission2 = false;  
    private bool isClearMission3 = false;  

    [HideInInspector] public int CurrentMissionNum = 0; 

    public bool isCharacterInExactPlace = false;  
    public bool isCameraInExactPlace = false;  
    public bool isNoCodeInExactPlace = false;  

    public bool getFinishCMButton = false;   

    private XRScreenManager xrScreenManager;  
    private ObjectSystemManager objectSystemManager;  

    void Start()
    {
        xrScreenManager = this.GetComponent<XRScreenManager>();  
        objectSystemManager = this.GetComponent<ObjectSystemManager>();  

        PlayerPrefs.SetInt("Mission1", 0);  
        PlayerPrefs.SetInt("Mission2", 0);  
        PlayerPrefs.SetInt("Mission3", 0);  
    }  

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            StartMission1();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            xrScreenManager.ActiveMission2Screen();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            xrScreenManager.ActiveMission3Screen();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            xrScreenManager.DeActiveAllMissionScreen();
        }
    }

    private void StartMission1()
    {
        xrScreenManager.ActiveMission1Screen(); 

        StartCoroutine(Mission1EventFlow()); 
    }

    private void StartMission2()
    {
        if (PlayerPrefs.GetInt("Mission1") == 1)
        {
            xrScreenManager.ActiveMission2Screen();

            StartCoroutine(Mission2EventFlow());
        }

    }

    private void StartMission3()
    {
        if (PlayerPrefs.GetInt("Mission2") == 1)
        {
            objectSystemManager.avatar3.SetActive(true); //Spawn Mage Avatar

            xrScreenManager.ActiveMission3Screen();

            StartCoroutine(Mission3EventFlow());
        }

    }

    private void FinishMission()
    {
        objectSystemManager.DeActiveXRSetting(); 
    } 

    public IEnumerator Mission1EventFlow() 
    {
        CurrentMissionNum = 1;
        yield return new WaitForSeconds(5);

        while ( isClearMission1 != true )
        {
            if (isCharacterInExactPlace
               && isCameraInExactPlace
               && isNoCodeInExactPlace
               && !objectSystemManager.isActiveStudioLight
               && getFinishCMButton) 
            {
                isClearMission1 = true; 
            }

            yield return null;
        }

        yield return new WaitForSeconds(5);
        objectSystemManager.returnObjectsToOriginSpace();
        xrScreenManager.DeActiveAllMissionScreen();

        PlayerPrefs.SetInt("Mission1",1);

        FinishMission();

        isCharacterInExactPlace = false;
        isCameraInExactPlace = false;
        isNoCodeInExactPlace = false;
    }

    public IEnumerator Mission2EventFlow()
    {
        CurrentMissionNum = 2;
        yield return new WaitForSeconds(5);

        while (isClearMission1 != true)
        {
            if (isCharacterInExactPlace
               && isCameraInExactPlace
               && isNoCodeInExactPlace
               && !objectSystemManager.isActiveStudioLight
               && getFinishCMButton)
            {
                isClearMission2 = true;
            }

            yield return null;
        }

        yield return new WaitForSeconds(5);
        objectSystemManager.returnObjectsToOriginSpace();
        xrScreenManager.DeActiveAllMissionScreen();

        PlayerPrefs.SetInt("Mission2", 1);

        FinishMission();

        isCharacterInExactPlace = false;
        isCameraInExactPlace = false;
        isNoCodeInExactPlace = false;
    }

    public IEnumerator Mission3EventFlow()
    {
        CurrentMissionNum = 3;
        yield return new WaitForSeconds(5);

        while (isClearMission1 != true)
        {
            if (isCharacterInExactPlace
               && isCameraInExactPlace
               && isNoCodeInExactPlace
               && !objectSystemManager.isActiveStudioLight
               && getFinishCMButton)
            {
                isClearMission3 = true;
            }

            yield return null;
        }

        yield return new WaitForSeconds(5);
        objectSystemManager.returnObjectsToOriginSpace();
        xrScreenManager.DeActiveAllMissionScreen();

        PlayerPrefs.SetInt("Mission3", 1);

        FinishMission();

        isCharacterInExactPlace = false;
        isCameraInExactPlace = false;
        isNoCodeInExactPlace = false;
    }
}
