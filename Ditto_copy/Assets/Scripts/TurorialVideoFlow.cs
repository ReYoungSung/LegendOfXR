using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurorialVideoFlow : MonoBehaviour
{
    //interactions
    public bool isHenaUIClosed = false; 
    
    public bool isArrivePoster = false;
    
    public bool isPressPoster = false;

    public bool isArriveAvatar = false;

    public bool isGrabAvatar = false;

    public bool isArriveXRScreen = false;
    
    public bool isPlaceDownAvatar = false;

    public bool isPlaceRuneStone = false;

    public bool isArriveCameraController = false;

    public bool isChangingXRCameraPosition = false;

    [SerializeField] private GameObject[] Videos; 

    int HenaUIClickNum = 0;
    int PosterUINum = 0;

    GameManager gameManager;

 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TutorialFlow());  
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TutorialFlow()  
    {
        Videos[0].SetActive(true);
        yield return new WaitForSecondsRealtime(29);
        Videos[0].SetActive(false);
        Videos[1].SetActive(true);
        yield return new WaitForSecondsRealtime(29);
        Videos[1].SetActive(false);

        HenaUIClickNum = 0;
        while ( isHenaUIClosed != true ) 
        {
            yield return null;
        }

        Videos[2].SetActive(true);
        yield return new WaitForSecondsRealtime(10);
        Videos[2].SetActive(false);

        isArrivePoster = false;
        while ( isArrivePoster != true ) 
        {
            yield return null;
        }

        Videos[3].SetActive(true);
        yield return new WaitForSecondsRealtime(20);
        Videos[3].SetActive(false);


        PosterUINum = 0;
        isPressPoster = false;
        while(isPressPoster != true) 
        {
            yield return null;
        }

        Videos[4].SetActive(true);
        yield return new WaitForSecondsRealtime(39);
        Videos[4].SetActive(false);

        while(isArriveAvatar != true) 
        {
            yield return null;
        }

        Videos[5].SetActive(true);
        yield return new WaitForSecondsRealtime(20);
        Videos[5].SetActive(false);

        
        isGrabAvatar = false;
        isArriveXRScreen = false;

        while (isGrabAvatar != true || isArriveXRScreen != true) 
        {
            yield return null;
        }

        Videos[6].SetActive(true);
        yield return new WaitForSecondsRealtime(11);
        Videos[6].SetActive(false);

        while (gameManager.isCharacterInExactPlace != true) 
        {
            yield return null;
        }

        Videos[7].SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        Videos[7].SetActive(false);

        while(isPlaceRuneStone != true) 
        {
            yield return null;
        }

        Videos[8].SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        Videos[8].SetActive(false);

       

        Videos[9].SetActive(true);
        yield return new WaitForSecondsRealtime(17);
        Videos[9].SetActive(false);

         while (gameManager.isNoCodeInExactPlace != true) 
        {
            yield return null;
        }

        Videos[10].SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        Videos[10].SetActive(false);

        while (isArriveCameraController != true) 
        {
            yield return null;
        }

        Videos[11].SetActive(true);
        yield return new WaitForSecondsRealtime(20);
        Videos[11].SetActive(false);

        while (gameManager.isNoCodeInExactPlace != true) 
        {
            yield return null;
        }

        Videos[12].SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        Videos[12].SetActive(false);



    }

    public void HenaUIClosed()
    {
        HenaUIClickNum ++;
        if(HenaUIClickNum >= 2)
            isHenaUIClosed = true;
    }

    public void PressedPoster()
    {
        isPressPoster = true;
    }

    public void GrabAvatar()
    {
        isGrabAvatar = true;    
    }

   
    
}
