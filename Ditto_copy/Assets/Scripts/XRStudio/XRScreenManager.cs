using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject XRCM;
    [SerializeField] private Transform Mission1CMTransform;
    [SerializeField] private Transform Mission2CMTransform;
    [SerializeField] private Transform Mission3CMTransform;

    [SerializeField] private GameObject XRFloorCM;
    [SerializeField] private Transform Mission1FloorCMTransform;
    [SerializeField] private Transform Mission2FloorCMTransform;
    [SerializeField] private Transform Mission3FloorCMTransform;

    private SoundManager soundManager;

    void Awake()
    {
        soundManager = this.GetComponent<SoundManager>();
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
            ActiveMission3Screcen();
        }
    }

    void ActiveMission1Screen()
    {
        soundManager.StopAllBGM();  
        soundManager.PlaySFX("CMScreenSFX"); 
        soundManager.PlayBGM("QUEST1"); 
        XRCM.transform.position = Mission1CMTransform.position; 
        XRFloorCM.transform.position = Mission1FloorCMTransform.position; 
    }

    void ActiveMission2Screen()
    {
        soundManager.StopAllBGM(); 
        soundManager.PlaySFX("CMScreenSFX"); 
        soundManager.PlayBGM("QUEST2"); 
        XRCM.transform.position = Mission2CMTransform.position; 
        XRFloorCM.transform.position = Mission2FloorCMTransform.position;  
    }

    void ActiveMission3Screcen()
    {
        soundManager.StopAllBGM(); 
        soundManager.PlaySFX("CMScreenSFX"); 
        soundManager.PlayBGM("QUEST3"); 
        XRCM.transform.position = Mission3CMTransform.position;  
        XRFloorCM.transform.position = Mission3FloorCMTransform.position; 
    }
}
