using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTargets : MonoBehaviour
{
    [SerializeField] private TurorialVideoFlow turorialVideoFlow;

    // Start is called before the first frame update
    void Start()
    {
        //turorialVideoFlow = GameObject.Find("TutorialVideoTimeline").GetComponent<TurorialVideoFlow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "FramePosition")
        {
            turorialVideoFlow.isArrivePoster = true;
        }

        if(other.name == "CMPosition")
        {
            turorialVideoFlow.isArriveCMScreen = true;
        }

        if(other.name == "AvatarPosition") 
        {
            turorialVideoFlow.isArriveAvatar = true;
        }

        if(other.name ==  "NoCodePosition")
        {
            turorialVideoFlow.isArriveRuneStonePlate = true;
        }

        if(other.name == "XRStudioPosition") 
        {
            turorialVideoFlow.isArriveXRScreen = true;
        }

        if(other.name == "RuneStoneArrive")
        {
            turorialVideoFlow.isArriveRuneStonePlate = true;
        }

        if (other.name == "RuneStoneTablet")
        {
            turorialVideoFlow.isGrabRuneStone = true;
        }
    }
}
