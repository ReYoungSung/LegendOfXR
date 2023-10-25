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
        noCodeManager = GameObject.Find("RuneStoneMissions").GetComponent<NoCodeManager>(); 
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
        {
            IsGrabed = true;
        }

        if(other.CompareTag("RuneStone"))
        {
            if(IsGrabed == false)
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
                    if(other.name == "BeginToPlay")
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
                else if (blankType == BlankType.Second)
                {
                    if (other.name == "12HourChanger")
                    {
                        noCodeManager.mission1Answers[1] = true;
                    }
                }
            }
            else if (missionType == MissionType.Mission2)
            {
                if(blankType == BlankType.First)
                {
                    if(other.name == "BeginToPlay")
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
                else if (blankType == BlankType.Second) 
                {
                    if (other.name == "12HourChanger")
                    {
                        noCodeManager.mission1Answers[1] = true;
                    }
                }
                else if (blankType == BlankType.Third) 
                {
                    if (other.name == "12HourChanger")
                    {
                        noCodeManager.mission1Answers[1] = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
        {
            IsGrabed = false;
        }

        if(other.CompareTag("RuneStone"))
        {
            if(other.name == "BeginToPlay")
            {
                noCodeManager.mission1Answers[0] = false; 
            }
        }
    }
}
