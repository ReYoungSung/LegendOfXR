

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class RuneStoneSensor : MonoBehaviour
{
    private NoCodeManager noCodeManager; 

    private bool IsGrabed = false;

    private bool isFilled = false;

    private GameObject filledObject;

    public TextMeshProUGUI textMeshPro;  

    private enum MissionType
    {
        None,
        Mission1,
        Mission2,
        Mission3
    }

    [SerializeField] private MissionType missionType = MissionType.None;

    private enum BlankType
    {
        First, 
        Second,
        Third,
        Fourth,
        Fifth
    }

    [SerializeField] private BlankType blankType = BlankType.First; 

    void Start()
    {
        noCodeManager = GameObject.Find("XRStudioSystemManager").GetComponent<NoCodeManager>(); 
        soundManager = GameObject.Find("XRStudioSystemManager").GetComponent<SoundManager>();
        textMeshPro = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();   
    }

    void Update() 
    {
        if(filledObject != null) 
        {
            if (missionType == MissionType.Mission1)  
            { 
                if(blankType == BlankType.First)
                {
                    noCodeManager.mission1FillBlank[0] = true; 

                    if (filledObject.name == "BeginToPlay")
                    {
                        ChangeText("시작 시 한 번");
                        noCodeManager.errorText1();
                        noCodeManager.mission1Answers[0] = false; 
                        noCodeManager.isRepeatEvent = false;
                    }
                    else if(filledObject.name == "TickEvent")
                    {
                        ChangeText("계속 반복해서");
                        noCodeManager.mission1Answers[0] = true; 
                        noCodeManager.isRepeatEvent = true; 
                    }
                    else
                    {
                        ChangeText("-Error-");
                    }
                }
            }
            else if(missionType == MissionType.Mission2)
            {
                if(blankType == BlankType.First)
                {
                    noCodeManager.mission2FillBlank[0] = true;

                    if (filledObject.name == "BeginToPlay")
                    {
                        ChangeText("시작 시 한 번");
                        noCodeManager.mission2Answers[0] = true;
                        noCodeManager.isRepeatEvent = false;
                    }
                    else if(filledObject.name == "TickEvent")
                    {
                        ChangeText("계속 반복해서");
                        noCodeManager.errorText2();
                        noCodeManager.mission2Answers[0] = false;   
                        noCodeManager.isRepeatEvent = true;
                    }
                    else
                    {
                        ChangeText("-Error-");
                    }
                }
                else if (blankType == BlankType.Second)
                {
                    noCodeManager.mission2FillBlank[1] = true;

                    if (filledObject.name == "12HourChanger") 
                    {
                        ChangeText("12시간 후로 돌린다");
                        noCodeManager.mission2Answers[1] = true;
                        noCodeManager.TimeValue = 12;
                    }
                    else if (filledObject.name == "6HourChanger")
                    {
                        ChangeText("6시간 후로 돌린다");
                        noCodeManager.mission2Answers[1] = false;
                        noCodeManager.TimeValue = 6;
                    }
                    else if (filledObject.name == "18HourChanger")
                    {
                        ChangeText("18시간 후로 돌린다");
                        noCodeManager.mission2Answers[1] = false;
                        noCodeManager.TimeValue = 18;
                    }
                    else if (filledObject.name == "24HourChanger")
                    {
                        ChangeText("24시간 후로 돌린다");
                        noCodeManager.mission2Answers[1] = false; 
                        noCodeManager.TimeValue = 24;
                    }
                    else
                    {
                        ChangeText("-Error-");
                    }
                }
            }
            else if (missionType == MissionType.Mission3)
            {
                if(blankType == BlankType.First)  //Shield
                {
                    noCodeManager.mission3FillBlank[0] = true;  

                    if(filledObject.name == "BeginToPlay")
                    {
                        ChangeText("시작 시 한 번");
                        noCodeManager.mission3Answers[0] = false;
                        noCodeManager.isRepeatEvent2 = false;
                    }
                    else if(filledObject.name == "TickEvent")
                    {
                        ChangeText("계속 반복해서"); 
                        noCodeManager.mission3Answers[0] = true;
                        noCodeManager.isRepeatEvent2 = true; 
                    }
                    else
                    {
                        ChangeText("-Error-");
                    }
                }
                else if (blankType == BlankType.Fourth)  //Shield 
                {
                    noCodeManager.mission3FillBlank[2] = true; 

                    if (filledObject.name == "Shield")
                    {
                        ChangeText("쉴드를 생성한다");
                        noCodeManager.mission3Answers[2] = true;
                    }
                    else if (filledObject.name == "Metheo")
                    {
                        ChangeText("메테오를 생성한다"); 
                        noCodeManager.mission3Answers[2] = false;
                        noCodeManager.errorText3(); 
                    }
                    else
                    {
                        ChangeText("-Error-");
                        ChangeText("메테오는 한번만!!"); 
                    } 
                }
                else if (blankType == BlankType.Second)  //Metheo
                {
                    noCodeManager.mission4FillBlank[0] = true;

                    if (filledObject.name == "BeginToPlay")
                    {
                        ChangeText("시작 시 한 번");
                        noCodeManager.mission4Answers[0] = true;
                        noCodeManager.isRepeatEvent = false;
                    }
                    else if (filledObject.name == "TickEvent")
                    {
                        ChangeText("계속 반복해서");
                        noCodeManager.mission4Answers[0] = false;
                        noCodeManager.isRepeatEvent = true;
                    }
                    else
                    {
                        ChangeText("-Error-");
                    }
                }
                else if (blankType == BlankType.Fifth)   //Metheo
                {
                    noCodeManager.mission4FillBlank[2] = true;

                    if (filledObject.name == "Metheo")
                    {
                        ChangeText("메테오를 생성한다"); 
                        noCodeManager.mission4Answers[2] = true;
                    }
                    else if (filledObject.name == "Shield")
                    {
                        ChangeText("쉴드를 생성한다");
                        noCodeManager.mission4Answers[2] = false;
                    }
                    else
                    {
                        ChangeText("-Error-");
                    }
                }
                else if (blankType == BlankType.Third)  //Wizard
                {
                    noCodeManager.mission3FillBlank[1] = true; 
                    noCodeManager.mission4FillBlank[1] = true;

                    if (filledObject.name == "Wizard") 
                    {
                        ChangeText("마법사가");  
                        noCodeManager.mission3Answers[1] = true;   
                        noCodeManager.mission4Answers[1] = true;  
                    }
                    else
                    {
                        ChangeText("-Error-");
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("RuneStone"))
        {
            soundManager.PlaySFX("PlaceRunstoneSFX");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("RuneStone"))
        {
            
            if (other.transform.GetComponent<RuneStoneGrabInteracterble>().isGrabbed == false)
            {
                if(filledObject == null)
                {
                    filledObject = other.gameObject;   
                }

                filledObject.transform.position = this.transform.position;
                var grabInteractable = filledObject.transform.GetComponent<RuneStoneGrabInteracterble>();

                if (grabInteractable != null)
                {
                    switch (grabInteractable.runeType)
                    {
                        case RuneStoneGrabInteracterble.RuneType.Rectangle:
                            filledObject.transform.localEulerAngles = new Vector3(190, 0, 0);
                            break;

                        case RuneStoneGrabInteracterble.RuneType.Triangle:
                            filledObject.transform.localEulerAngles = new Vector3(-170, 0, 0);
                            break;

                        case RuneStoneGrabInteracterble.RuneType.Circle:
                            filledObject.transform.localEulerAngles = new Vector3(11, 0, 0);
                            break;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("RuneStone"))
        {
            noCodeManager.mission1Answers[0] = false;
            noCodeManager.mission2Answers[0] = false;
            noCodeManager.mission2Answers[1] = false;
            
            noCodeManager.mission3Answers[1] = false;
            noCodeManager.mission3Answers[2] = false;
            
            noCodeManager.mission4Answers[1] = false;
            noCodeManager.mission4Answers[2] = false;

            noCodeManager.mission1FillBlank[0] = false;
            noCodeManager.mission2FillBlank[0] = false;
            noCodeManager.mission2FillBlank[1] = false;
            
            noCodeManager.mission3FillBlank[1] = false;
            noCodeManager.mission3FillBlank[2] = false;
            
            noCodeManager.mission4FillBlank[1] = false;
            noCodeManager.mission4FillBlank[2] = false;

            if(filledObject != null)
                filledObject = null;

            ChangeText("???"); 
            noCodeManager.resetText();  
        }
    }

    public void ChangeText(string newText) 
    {
        textMeshPro.text = newText;  
    }
}
