using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCodeManager : MonoBehaviour
{
    private GameManager gameManager;

    public bool[] mission1Answers = new bool[] {false};
    public bool[] mission2Answers = new bool[] {false, false};
    public bool[] mission3Answers = new bool[] {false, false, false};

    [HideInInspector] public bool isRepeatEvent = false;
    [SerializeField] private GameObject WatarSordVFX;

    [HideInInspector] public bool IsPlayButtonDown = false; 

    private void Awake()
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        if(gameManager.CurrentMissionNum == 1)
        {
            if (mission1Answers[0] && IsPlayButtonDown) 
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }
        else if(gameManager.CurrentMissionNum == 2)
        {
            if (mission2Answers[0] && mission2Answers[1] && IsPlayButtonDown)
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }
        else if (gameManager.CurrentMissionNum == 3)
        {
            if (mission3Answers[0] && mission3Answers[1] && mission3Answers[3] && IsPlayButtonDown)
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }
    }

    IEnumerator Mission1RuneStoneFlow() 
    {
        yield return new WaitForSeconds(2.0f); 
        if(isRepeatEvent == false)
        {
            //WatarSordVFX.setActive(true);
            
        }
    }
}
