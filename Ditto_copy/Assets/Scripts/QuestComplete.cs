using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class QuestComplete : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Image uiImage1;
    [SerializeField] private Image uiImage2;
    [SerializeField] private Image uiImage3;

    void Start()
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();

    }

    void Update()
    {
          if (gameManager.isCharacterInExactPlace)
    {
        uiImage1.color = Color.green;
    }
        else
    {
        uiImage1.color = Color.red;
        
    }
      
          if (gameManager.isNoCodeInExactPlace)
    {
        uiImage2.color = Color.green;
    }
        else
    {
        uiImage2.color = Color.red;
        
    }
      
          if ( gameManager.isCameraInExactPlace) 
    {
        uiImage3.color = Color.green;
    }
        else
    {
        uiImage3.color = Color.red;
    }
    }
    
}
