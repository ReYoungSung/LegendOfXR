using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCodeManager : MonoBehaviour
{
    private GameManager gameManager;

    private bool[] mission1Answers = new bool[] {false, false, false};  
    private bool[] mission2Answers = new bool[] {false, false, false};
    private bool[] mission3Answers = new bool[] {false, false, false};

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
            if (mission1Answers[0] && mission1Answers[1] && mission1Answers[3])
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
            if (mission2Answers[0] && mission2Answers[1] && mission2Answers[3])
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
            if (mission3Answers[0] && mission3Answers[1] && mission3Answers[3])
            {
                gameManager.isNoCodeInExactPlace = true;
            }
            else
            {
                gameManager.isNoCodeInExactPlace = false;
            }
        }
    }
}
