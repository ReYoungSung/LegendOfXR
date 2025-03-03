using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

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

    public Camera PlayerCamera; // ù   ° ī ޶ 
    public Camera XRCamera; //      ° ī ޶ 

    public PlayableDirector WizardTimeline;

    public GameObject mission1ClearImage;
    public GameObject mission2ClearImage;
    public GameObject mission3ClearImage;

    SoundManager soundManager;

    void Start()
    {
        //  ʱ⿡   ù   ° ī ޶  Ȱ  ȭ
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

        soundManager = this.GetComponent<SoundManager>();
    }   

    void Update()
    {
        //         , Ű  Է        Ͽ  ī ޶    ȯ
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
        xrScreenManager.ActiveMission2Screen();  
        RuneStonePlates[0].SetActive(false);
        RuneStonePlates[1].SetActive(true);
        RuneStonePlates[2].SetActive(false);
        StartCoroutine(Mission2EventFlow());

        if (PlayerPrefs.GetInt("Mission1") == 1)
        {
            
        }
    }

    public void StartMission3()
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
        
        if (PlayerPrefs.GetInt("Mission2") == 1 && PlayerPrefs.GetInt("Mission1") == 1)
        {
            
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
        noCodeManager.resetText(); 
        
        noCodeManager.isRepeatEvent = false;
        noCodeManager.isRepeatEvent2 = false;
        noCodeManager.IsPlayButtonDown = false;   
    }


    //완료시 애니메이션
    public void SetAnimatorBool(string animatorName, string boolParameter, bool value)
    {
        Animator animator = GameObject.Find(animatorName)?.GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetBool(boolParameter, value);
        }
        else
        {
            Debug.LogError("Animator not found: " + animatorName);
        }
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

                // 클리어 시 Animator 컴포넌트의 "Quest1Bool" 파라미터를 true로 설정
                if (isClearMission1)
                {
                    Animator animator = GetComponent<Animator>(); // GameManager 게임 오브젝트의 Animator 컴포넌트 가져오기
                    if (animator != null)
                    {
                        SetAnimatorBool("Q1_Golem_XR", "Quest1Bool", true);
                    }
                }

            }

            yield return null; 
        }
        changeCamera(); 
        soundManager.PlaySFX("QuestClearSFX");
        yield return new WaitForSeconds(5); 
        
        PlayerPrefs.SetInt("Mission1",1); 

        mission1ClearImage.SetActive(true); 
        yield return new WaitForSeconds(3); 
        mission1ClearImage.SetActive(false); 

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
                if (isClearMission2)
                {
                    Animator animator = GetComponent<Animator>(); // GameManager 게임 오브젝트의 Animator 컴포넌트 가져오기
                    if (animator != null)
                    {
                        SetAnimatorBool("Q2_Priest_XR", "Quest2Bool", true);
                        SetAnimatorBool("Q2_Saint_anim", "Quest2Bool", true);
                    }
                }

            }

            yield return null;
        }
        changeCamera();
        soundManager.PlaySFX("QuestClearSFX");
        yield return new WaitForSeconds(5);

        PlayerPrefs.SetInt("Mission2", 1);

        mission2ClearImage.SetActive(true);
        yield return new WaitForSeconds(3);
        mission2ClearImage.SetActive(false);

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
                if (isClearMission3)
                {
                    Animator animator = GetComponent<Animator>(); // GameManager 게임 오브젝트의 Animator 컴포넌트 가져오기
                    if (animator != null)
                    {
                        SetAnimatorBool("Q3_Drake_XR", "Quest3Bool", true);
                        SetAnimatorBool("Q3_Wizard_anim", "Quest3Bool", true);
                    }
                }

            }

            yield return null;
        }
        changeCamera();
        soundManager.PlaySFX("QuestClearSFX");
        yield return new WaitForSeconds(5);

        PlayerPrefs.SetInt("Mission3", 1);

        mission3ClearImage.SetActive(true);
        yield return new WaitForSeconds(3);
        mission3ClearImage.SetActive(false);

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
        soundManager.PlayShutter();
    }

}
