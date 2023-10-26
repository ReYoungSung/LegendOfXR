using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStoneSensor : MonoBehaviour
{
    private NoCodeManager noCodeManager; 

    private bool IsGrabed = false;

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
        Third
    }

    [SerializeField] private BlankType blankType = BlankType.First; 

    void Start()
    {
        noCodeManager = GameObject.Find("XRStudioSystemManager").GetComponent<NoCodeManager>(); 
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("RuneStone"))
        {
            if (other.transform.GetComponent<RuneStoneGrabInteracterble>().isGrabbed == false)
            {
                other.transform.position = this.transform.position;  
                other.transform.localEulerAngles = new Vector3(-90,0,0);
            }

            if (missionType == MissionType.Mission1) 
            {
                if(blankType == BlankType.First)
                {
                    noCodeManager.mission1FillBlank[0] = true; 

                    if (other.name == "BeginToPlay")
                    {
                        noCodeManager.mission1Answers[0] = false;
                        noCodeManager.isRepeatEvent = false;
                    }

                    if(other.name == "TickEvent")
                    {
                        noCodeManager.mission1Answers[0] = true;
                        noCodeManager.isRepeatEvent = true; 
                    }
                }
            }
            else if(missionType == MissionType.Mission2)
            {
                if(blankType == BlankType.First)
                {
                    noCodeManager.mission2FillBlank[0] = true;

                    if (other.name == "BeginToPlay")
                    {
                        noCodeManager.mission2Answers[0] = true;
                        noCodeManager.isRepeatEvent = false;
                    }

                    if(other.name == "TickEvent")
                    {
                        noCodeManager.mission2Answers[0] = false;   
                        noCodeManager.isRepeatEvent = true;
                    }
                }
                else if (blankType == BlankType.Second)
                {
                    noCodeManager.mission2FillBlank[1] = true;

                    if (other.name == "12HourChanger") 
                    {
                        noCodeManager.mission2Answers[1] = true;
                        noCodeManager.TimeValue = 12;
                    }

                    if (other.name == "6HourChanger")
                    {
                        noCodeManager.mission2Answers[1] = false;
                        noCodeManager.TimeValue = 6;
                    }

                    if (other.name == "18HourChanger")
                    {
                        noCodeManager.mission2Answers[1] = false;
                        noCodeManager.TimeValue = 18;
                    }

                    if (other.name == "24HourChanger")
                    {
                        noCodeManager.mission2Answers[1] = false;
                        noCodeManager.TimeValue = 24;
                    }

                }
            }
            else if (missionType == MissionType.Mission3)
            {
                if(blankType == BlankType.First)
                {
                    if(other.name == "BeginToPlay")
                    {
                        noCodeManager.mission3Answers[0] = false;
                        noCodeManager.isRepeatEvent = false;
                    }

                    if(other.name == "TickEvent")
                    {
                        noCodeManager.mission3Answers[0] = true;
                        noCodeManager.isRepeatEvent = true;
                    }
                }
                else if (blankType == BlankType.Second) 
                {
                    if (other.name == "12HourChanger")
                    {
                        noCodeManager.mission3Answers[1] = true;
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
            noCodeManager.mission3Answers[0] = false;
            noCodeManager.mission3Answers[1] = false;
            noCodeManager.mission3Answers[2] = false;

            noCodeManager.mission1FillBlank[0] = true;
            noCodeManager.mission2FillBlank[0] = true;
            noCodeManager.mission2FillBlank[1] = true;
            noCodeManager.mission3FillBlank[0] = true;
            noCodeManager.mission3FillBlank[1] = true;
            noCodeManager.mission3FillBlank[2] = true;
        }
    }
}
