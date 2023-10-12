using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isClearMission1 = false; 
    private bool isClearMission2 = false; 
    private bool isClearMission3 = false;

    [HideInInspector] public bool isStudioBlackOut = false;
    [HideInInspector] public bool isCharacterInExactPlace = false;
    [HideInInspector] public bool isCameraInExactPlace = false;
    [HideInInspector] public bool isNoCodeInExactPlace = false;

    [HideInInspector] public bool getFinishCMButton = false;   

    private XRScreenManager xrScreenManager;
    private ObjectSystemManager objectSystemManager;

    

    void Start()
    {
        xrScreenManager = this.GetComponent<XRScreenManager>();

        PlayerPrefs.SetInt("Mission1", 0);
        PlayerPrefs.SetInt("Mission2", 0);
        PlayerPrefs.SetInt("Mission3", 0);
    }

    void Update()
    {
        
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
        }

    }

    private void StartMission3()
    {
        if (PlayerPrefs.GetInt("Mission2") == 1)
        {
            objectSystemManager.avatar3.SetActive(true); //Spawn Mage Avatar

            xrScreenManager.ActiveMission3Screen();
        }

    }

    private void FinishMission()
    {
        objectSystemManager.DeActiveXRSetting(); 
    } 

    public IEnumerator Mission1EventFlow()
    {
        yield return new WaitForSeconds(5);

        while ( isClearMission1 != true )
        {
            if(isCharacterInExactPlace == true)
            {
                //Please put the UI success display switch function here.
            }
            else
            {
                //Bandelo
            }

            if (isCameraInExactPlace == true)
            {
                //Please put the UI success display switch function here.
            }
            else
            {
                //Bandelo
            }

            if (isNoCodeInExactPlace == true)
            {
                //Please put the UI success display switch function here.
            }
            else
            {
                //Bandelo
            } 

            if (isCharacterInExactPlace
               && isCameraInExactPlace
               && isNoCodeInExactPlace
               && isStudioBlackOut
               && getFinishCMButton) 
            {
                isClearMission1 = true; 
            }

            yield return null;
        }

        yield return new WaitForSeconds(5);
        objectSystemManager.returnObjectsToOriginSpace();

        PlayerPrefs.SetInt("Mission1",1);

        FinishMission();

        isCharacterInExactPlace = false;
        isCameraInExactPlace = false;
        isNoCodeInExactPlace = false;
    } 
}
