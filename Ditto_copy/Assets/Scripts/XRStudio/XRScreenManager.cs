using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject XRCM; 
    [SerializeField] private Transform Mission1CMTransform; 
    [SerializeField] private Transform Mission2CMTransform; 
    [SerializeField] private Transform Mission3CMTransform; 
    [SerializeField] private Transform NoMissionCMTransform;  

    [SerializeField] private GameObject XRFloorCM; 
    [SerializeField] private Transform Mission1FloorCMTransform; 
    [SerializeField] private Transform Mission2FloorCMTransform; 
    [SerializeField] private Transform Mission3FloorCMTransform; 
    [SerializeField] private Transform NoMissionFloorCMTransform;  

    private SoundManager soundManager; 

    [HideInInspector] public bool isActiveMission1 = false; 
    [HideInInspector] public bool isActiveMission2 = false; 
    [HideInInspector] public bool isActiveMission3 = false;  

    void Awake()
    {
        soundManager = this.GetComponent<SoundManager>();
    }

    void Start()
    {
        soundManager.StopAllBGM();    
        soundManager.PlayBGM("XRStudioBGM");  
        XRCM.transform.position = NoMissionCMTransform.position;   
        XRFloorCM.transform.position = NoMissionFloorCMTransform.position;  
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ActiveMission1Screen();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ActiveMission2Screen(); 
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            ActiveMission3Screen(); 
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            DeActiveAllMissionScreen(); 
        }
    }

    public void DeActiveAllMissionScreen()
    {   
        soundManager.StopAllBGM();   
        soundManager.PlaySFX("CMScreenSFX");  
        soundManager.PlayBGM("XRStudioBGM");  
        XRCM.transform.position = NoMissionCMTransform.position;   
        XRFloorCM.transform.position = NoMissionFloorCMTransform.position;  
        isActiveMission1 = false; 
        isActiveMission2 = false; 
        isActiveMission3 = false; 
    }


    public void ActiveMission1Screen()
    {
        soundManager.StopAllBGM();  
        soundManager.PlaySFX("CMScreenSFX"); 
        soundManager.PlayBGM("QUEST1"); 
        XRCM.transform.position = Mission1CMTransform.position; 
        XRFloorCM.transform.position = Mission1FloorCMTransform.position; 
        isActiveMission1 = true;
        isActiveMission2 = false;
        isActiveMission3 = false;
    }

    public void ActiveMission2Screen()
    {
        soundManager.StopAllBGM(); 
        soundManager.PlaySFX("CMScreenSFX"); 
        soundManager.PlayBGM("QUEST2"); 
        XRCM.transform.position = Mission2CMTransform.position; 
        XRFloorCM.transform.position = Mission2FloorCMTransform.position;  
        isActiveMission1 = false;
        isActiveMission2 = true;
        isActiveMission3 = false;
    }

    public void ActiveMission3Screen()
    {
        soundManager.StopAllBGM(); 
        soundManager.PlaySFX("CMScreenSFX"); 
        soundManager.PlayBGM("QUEST3"); 
        XRCM.transform.position = Mission3CMTransform.position;  
        XRFloorCM.transform.position = Mission3FloorCMTransform.position; 
        isActiveMission1 = false;
        isActiveMission2 = false;
        isActiveMission3 = true;
    }
}
