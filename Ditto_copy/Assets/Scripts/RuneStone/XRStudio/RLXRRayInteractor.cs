using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class RLXRRayInteractor : XRRayInteractor
{
    private enum RL
    {
        RightHand,
        LeftHand
    }

    [SerializeField] private RL rl = RL.RightHand;

    [SerializeField] private Transform rayOrigin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
