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

    public bool isArriveXRScreen2 = false;

    public bool isRecommendOn = false;
    
    public bool isPlaceDownAvatar = false;

    public bool isPlaceRuneStone = false;

    public bool isArriveCameraController = false;

    public bool isChangingXRCameraPosition = false;

    [SerializeField] private GameObject[] Videos;
    [SerializeField] private GameObject Texture;
    [SerializeField] private GameObject[] UIImages;

    int HenaUIClickNum = 0;
    int PosterUINum = 0;
    int RecommendOnNum = 0;

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
        Texture.SetActive(true);
        Videos[0].SetActive(true);
        yield return new WaitForSecondsRealtime(35);
        Videos[0].SetActive(false);
       
        Videos[1].SetActive(true);
        yield return new WaitForSecondsRealtime(35);
        Videos[1].SetActive(false);
        Texture.SetActive(false);

        UIImages[0].SetActive(true);
        UIImages[1].SetActive(true);

        HenaUIClickNum = 0;
        isHenaUIClosed = false; 
        while ( isHenaUIClosed != true ) 
        {
            yield return null;
        }

        UIImages[0].SetActive(false);
        UIImages[1].SetActive(false);

        Texture.SetActive(true);
        Videos[2].SetActive(true);
        yield return new WaitForSecondsRealtime(15);
        Videos[2].SetActive(false);
        Texture.SetActive(false);

        isArrivePoster = false;
        while ( isArrivePoster != true ) 
        {
            yield return null;
        }

          // add  videos 
        Texture.SetActive(true);
        Videos[3].SetActive(true);
        yield return new WaitForSecondsRealtime(13);
        Videos[3].SetActive(false);
        Texture.SetActive(false);

        isArriveXRScreen2 = false;
        while (isArriveXRScreen2 != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[4].SetActive(true);
        yield return new WaitForSecondsRealtime(13);
        Videos[4].SetActive(false);
        Texture.SetActive(false);

        RecommendOnNum = 0;
        isRecommendOn = false; 
        while (isRecommendOn != true) 
        {
            yield return null;
        }
        // finish add

        Texture.SetActive(true);
        Videos[5].SetActive(true);
        yield return new WaitForSecondsRealtime(22);
        Videos[5].SetActive(false);
        Texture.SetActive(false);


        PosterUINum = 0;
        isPressPoster = false;
        while(isPressPoster != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[6].SetActive(true);
        yield return new WaitForSecondsRealtime(39);
        Videos[6].SetActive(false);
        Texture.SetActive(false);

        isArriveAvatar = false;
        while(isArriveAvatar != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[7].SetActive(true);
        yield return new WaitForSecondsRealtime(25);
        Videos[7].SetActive(false);
        Texture.SetActive(false);


        isGrabAvatar = false;
        isArriveXRScreen = false;
        while (isGrabAvatar != true || isArriveXRScreen != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[8].SetActive(true);
        yield return new WaitForSecondsRealtime(16);
        Videos[8].SetActive(false);
        Texture.SetActive(false);

        gameManager.isCharacterInExactPlace = false;
        while (gameManager.isCharacterInExactPlace != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[9].SetActive(true);
        yield return new WaitForSecondsRealtime(14);
        Videos[9].SetActive(false);
        Texture.SetActive(false);

        isPlaceRuneStone = false;
        while(isPlaceRuneStone != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[10].SetActive(true);
        yield return new WaitForSecondsRealtime(17);
        Videos[10].SetActive(false);
        Texture.SetActive(false);

        Texture.SetActive(true);
        Videos[11].SetActive(true);
        yield return new WaitForSecondsRealtime(23);
        Videos[11].SetActive(false);
        Texture.SetActive(false);


        gameManager.isNoCodeInExactPlace = false;
         while (gameManager.isNoCodeInExactPlace != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[12].SetActive(true);
        yield return new WaitForSecondsRealtime(10);
        Videos[12].SetActive(false);
        Texture.SetActive(false);


        isArriveCameraController = false;
        while (isArriveCameraController != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[13].SetActive(true);
        yield return new WaitForSecondsRealtime(20);
        Videos[13].SetActive(false);
        Texture.SetActive(false);


        gameManager.isNoCodeInExactPlace = false;
        while (gameManager.isNoCodeInExactPlace != true) 
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[14].SetActive(true);
        yield return new WaitForSecondsRealtime(8);
        Videos[14].SetActive(false);
        Texture.SetActive(false);

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

    public void RecommendOn() 
    {
        isRecommendOn = true;
    }

   
    
}
