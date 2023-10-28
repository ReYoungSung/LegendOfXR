using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public bool isClearMission1 = false;
    public bool isClearMission2 = false;
    public bool isClearMission3 = false;  

    [HideInInspector] public int CurrentMissionNum = 0; 

    public bool isCharacterInExactPlace = false;  
    public bool isCameraInExactPlace = false;  
    public bool isNoCodeInExactPlace = false;  

    public bool getFinishCMButton = false;   

    private XRScreenManager xrScreenManager;  
    private ObjectSystemManager objectSystemManager;
    private NoCodeManager noCodeManager;

    [SerializeField] private GameObject[] MissionLogos;

    [SerializeField] private GameObject[] RuneStonePlates;

    public Camera PlayerCamera; // ù ��° ī�޶�
    public Camera XRCamera; // �� ��° ī�޶�

    public PlayableDirector WizardTimeline;



    void Start()
    {
        // �ʱ⿡�� ù ��° ī�޶� Ȱ��ȭ
        PlayerCamera.enabled = true;
        XRCamera.enabled = false;

        xrScreenManager = this.GetComponent<XRScreenManager>();  
        objectSystemManager = this.GetComponent<ObjectSystemManager>();  
        noCodeManager = this.GetComponent<NoCodeManager>();

        PlayerPrefs.SetInt("Mission1", 0);  
        PlayerPrefs.SetInt("Mission2", 0);  
        PlayerPrefs.SetInt("Mission3", 0);

        CurrentMissionNum = 0; 
        changeMissionLogo();
    }   

    void Update()
    {
        // ���� ���, Ű �Է��� ����Ͽ� ī�޶� ��ȯ
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerCamera.enabled = !PlayerCamera.enabled;
            XRCamera.enabled = !XRCamera.enabled;
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            StartMission1();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            xrScreenManager.ActiveMission2Screen();
            StartMission2();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            xrScreenManager.ActiveMission3Screen();
            StartMission3();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            xrScreenManager.DeActiveAllMissionScreen(); 
        }
    }

    public void StartMission1()
    {
        xrScreenManager.ActiveMission1Screen();   
        RuneStonePlates[0].SetActive(true);    
        RuneStonePlates[1].SetActive(false);    
        RuneStonePlates[2].SetActive(false);    
        StartCoroutine(Mission1EventFlow());    
    }

    public void StartMission2()
    {
        if (PlayerPrefs.GetInt("Mission1") == 1)
        {
            xrScreenManager.ActiveMission2Screen();  
            RuneStonePlates[0].SetActive(false);
            RuneStonePlates[1].SetActive(true);
            RuneStonePlates[2].SetActive(false);
            StartCoroutine(Mission2EventFlow());
        }
    }

    public void StartMission3()
    {
        if (PlayerPrefs.GetInt("Mission2") == 1 && PlayerPrefs.GetInt("Mission1") == 1)
        {
            objectSystemManager.avatar3.SetActive(true); //Spawn Mage Avatar
            objectSystemManager.WizardRuneStone.SetActive(true);

            xrScreenManager.ActiveMission3Screen();
            RuneStonePlates[0].SetActive(false);
            RuneStonePlates[1].SetActive(false);
            RuneStonePlates[2].SetActive(true);
            StartCoroutine(Mission3EventFlow());

            // WizardTimeline 실행
            if (WizardTimeline != null)
            {
                WizardTimeline.Play();
            }
        }
    }

    private void FinishMission()
    {
        objectSystemManager.returnObjectsToOriginSpace();
        xrScreenManager.DeActiveAllMissionScreen();
        isCharacterInExactPlace = false;
        isCameraInExactPlace = false;
        isNoCodeInExactPlace = false;
        getFinishCMButton = false;
        noCodeManager.StopRuneStone(); 
    } 

    public IEnumerator Mission1EventFlow() 
    {
        CurrentMissionNum = 1;
        changeMissionLogo();
        yield return new WaitForSeconds(5);

        while ( isClearMission1 != true )
        {
            if (isCharacterInExactPlace
               && isCameraInExactPlace
               && isNoCodeInExactPlace
               && getFinishCMButton) 
            {
                isClearMission1 = true; 
            }

            yield return null;
        }
        changeCamera();
        yield return new WaitForSeconds(10);
        
        PlayerPrefs.SetInt("Mission1",1);

        changeCamera();
        FinishMission();
    }

    public IEnumerator Mission2EventFlow()
    {
        CurrentMissionNum = 2;
        changeMissionLogo();
        yield return new WaitForSeconds(5);

        while (isClearMission2 != true)
        {
            if (isCharacterInExactPlace
               && isCameraInExactPlace
               && isNoCodeInExactPlace
               && getFinishCMButton)
            {
                isClearMission2 = true;
            }

            yield return null;
        }
        changeCamera();
        yield return new WaitForSeconds(10);

        PlayerPrefs.SetInt("Mission2", 1);

        changeCamera();
        FinishMission();
    }

    public IEnumerator Mission3EventFlow()
    {
        CurrentMissionNum = 3;
        changeMissionLogo();
        yield return new WaitForSeconds(5);

        while (isClearMission3 != true)
        {
            if (isCharacterInExactPlace
               && isCameraInExactPlace
               && isNoCodeInExactPlace
               && getFinishCMButton)
            {
                isClearMission3 = true;
            }

            yield return null;
        }
        changeCamera();
        yield return new WaitForSeconds(10);

        PlayerPrefs.SetInt("Mission3", 1);

        changeCamera();
        FinishMission();
    }

    public void changeMissionLogo()  
    {
        for(int i = 0; i < MissionLogos.Length; i++)
        {
            for(int b = 0; b < MissionLogos[i].transform.childCount; b++)
            {
                MissionLogos[i].transform.GetChild(b).gameObject.SetActive(false); 
            }
            MissionLogos[i].transform.GetChild(CurrentMissionNum).gameObject.SetActive(true);
        }
    }

    public void changeCamera()
    {
        PlayerCamera.enabled = !PlayerCamera.enabled;
        XRCamera.enabled = !XRCamera.enabled;
    }

    public void GetClearButtonDown()
    {
        getFinishCMButton = true;
    }

}
