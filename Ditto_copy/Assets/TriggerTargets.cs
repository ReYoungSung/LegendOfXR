using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTargets : MonoBehaviour
{
    private TurorialVideoFlow turorialVideoFlow;

    // Start is called before the first frame update
    void Start()
    {
        turorialVideoFlow = GameObject.Find("TutorialVideoTimeline").GetComponent<TurorialVideoFlow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FramePosition")
        {
            turorialVideoFlow.isArrivePoster = true;
        }

        if(other.name == "XRStudioPosition")
        {
            turorialVideoFlow.isArriveXRScreen = true;
        }
    }
}
