using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStoneSensor : MonoBehaviour
{
    private NoCodeManager noCodeManager; 

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
        if(other.CompareTag("RuneStone"))
        {
            other.transform.position = this.transform.position;

            if (missionType == MissionType.Mission1) 
            {
                if(blankType == BlankType.First)
                {
                    if(other.name == "BeginToPlay")
                    {
                        noCodeManager.mission1Answers[0] = true;
                    }
                }
                else if(blankType == BlankType.Second)
                {
                    if (other.name == "WaterSwordEffect") 
                    {
                        noCodeManager.mission1Answers[1] = true;
                    }
                }
            }
            else if(missionType == MissionType.Mission2)
            {
                if (blankType == BlankType.First)
                {
                    if (other.name == "TickEvent")
                    {
                        noCodeManager.mission1Answers[0] = true;
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
                if (blankType == BlankType.First)
                {
                    if (other.name == "TickEvent")
                    {
                        noCodeManager.mission1Answers[0] = true;
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
        }
    }
}
