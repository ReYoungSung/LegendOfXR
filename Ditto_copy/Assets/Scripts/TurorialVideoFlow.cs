using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurorialVideoFlow : MonoBehaviour
{
    //interactions
    public bool isHenaUIClosed = false;

    public bool isArriveCMScreen = false;

    public bool isArriveXRScreen = false;

    public bool isRecommendOn = false;

    public bool isArrivePoster = false;

    public bool isPressPoster = false;

    public bool isArriveAvatar = false;

    public bool isArriveRuneStonePlate = false;

    public bool isGrabAvatar = false;

    public bool isGrabRuneStone = false;

    public bool isPlaceRuneStone = false;

    public bool isRunePLayButton = false;

    public bool isArriveXRScreen2 = false;

    public bool isArriveCameraController = false;

    public bool isChangingXRCameraPosition = false;

    public bool isQuestStart2 = false;
    public bool isQuestStart3 = false;

    [SerializeField] private GameObject[] Videos;
    [SerializeField] private GameObject Texture;
    [SerializeField] private GameObject[] UIImages;
    [SerializeField] private GameObject Navigation;

    int HenaUIClickNum = 0;
    int PosterUINum = 0;
    int RecommendOnNum = 0;

    GameManager gameManager;
    NavSystem navSystem;

 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TutorialFlow());  
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
        navSystem = GameObject.Find("NavArrowSystem").GetComponent<NavSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TutorialFlow()  
    {
        yield return new WaitForSeconds(4.0f);

        Texture.SetActive(true);
        Videos[0].SetActive(true);
        yield return new WaitForSecondsRealtime(29);
        Videos[0].SetActive(false);
       
        Videos[1].SetActive(true);
        yield return new WaitForSecondsRealtime(31);
        Videos[1].SetActive(false);
        Texture.SetActive(false);

        UIImages[0].SetActive(true);
        UIImages[1].SetActive(true);

        HenaUIClickNum = 0;
        isHenaUIClosed = false; 
        while ( isHenaUIClosed != true) 
        {
            yield return null;
        }

        UIImages[0].SetActive(false);
        UIImages[1].SetActive(false);

        yield return new WaitForSeconds(2.0f);

        Texture.SetActive(true);
        Videos[2].SetActive(true);
        yield return new WaitForSecondsRealtime(12);    
        Videos[2].SetActive(false);
        Texture.SetActive(false);

        navSystem.selectNavTarget(4);
        Navigation.SetActive(true);       

        isArriveCMScreen = false;
        while (isArriveCMScreen != true )
        {
            yield return null;
        }

        Navigation.SetActive(false);

        yield return new WaitForSeconds(1.0f);
          // add  videos 
        Texture.SetActive(true);
        Videos[3].SetActive(true);
        yield return new WaitForSecondsRealtime(12);
        Videos[3].SetActive(false);
        Texture.SetActive(false);


        RecommendOnNum = 0;
        isRecommendOn = false;
        while (isRecommendOn != true)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);

        Texture.SetActive(true);
        Videos[4].SetActive(true);
        yield return new WaitForSecondsRealtime(11);
        Videos[4].SetActive(false);  
        Texture.SetActive(false);

        navSystem.selectNavTarget(1);
        Navigation.SetActive(true);

        isArrivePoster = false;

        while (isArrivePoster != true)
        {
            yield return null;
        }

        Navigation.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        Texture.SetActive(true);
        Videos[5].SetActive(true);
        yield return new WaitForSecondsRealtime(22);
        Videos[5].SetActive(false);
        Texture.SetActive(false);

        PosterUINum = 0;
        isPressPoster = false;
        while (isPressPoster != true)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        Texture.SetActive(true);
        Videos[6].SetActive(true);
        yield return new WaitForSecondsRealtime(42);
        Videos[6].SetActive(false);
        Texture.SetActive(false);

        navSystem.selectNavTarget(2);
        Navigation.SetActive(true);

        isArriveAvatar = false;
        while (isArriveAvatar != true)
        {
            yield return null;
        }

        Navigation.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        Texture.SetActive(true);
        Videos[7].SetActive(true);
        yield return new WaitForSecondsRealtime(22);
        Videos[7].SetActive(false);
        Texture.SetActive(false);

        navSystem.selectNavTarget(5);
        Navigation.SetActive(true);

        isArriveXRScreen = false;
        while (isArriveXRScreen != true)
        {
            yield return null;
        }

        Navigation.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        Texture.SetActive(true);
        Videos[8].SetActive(true);
        yield return new WaitForSecondsRealtime(14);
        Videos[8].SetActive(false);
        Texture.SetActive(false);

        isGrabAvatar = false;
        isArriveXRScreen = false;
        gameManager.isCharacterInExactPlace = false;

        while (gameManager.isCharacterInExactPlace !=true)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        Texture.SetActive(true);
        Videos[9].SetActive(true);
        yield return new WaitForSecondsRealtime(10);
        Videos[9].SetActive(false);
        Texture.SetActive(false);

        navSystem.selectNavTarget(3);
        Navigation.SetActive(true);

        // Runestone play button activate -> nest mission : button 
        isArriveRuneStonePlate = false;
        while (isArriveRuneStonePlate != true)
        {
            yield return null;
        }

        Navigation.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        Texture.SetActive(true);
        Videos[10].SetActive(true);
        yield return new WaitForSecondsRealtime(19);
        Videos[10].SetActive(false);
        Texture.SetActive(false);

        isGrabRuneStone = false;
        while (isGrabRuneStone != true)
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[11].SetActive(true);
        yield return new WaitForSecondsRealtime(22);
        Videos[11].SetActive(false);
        Texture.SetActive(false);

        isRunePLayButton = false;
        gameManager.isNoCodeInExactPlace = false;

        while (gameManager.isNoCodeInExactPlace != true || isRunePLayButton != true)
        {
            yield return null;
        }

        Texture.SetActive(true);
        Videos[12].SetActive(true);
        yield return new WaitForSecondsRealtime(6);
        Videos[12].SetActive(false);
        Texture.SetActive(false);

        navSystem.selectNavTarget(4);
        Navigation.SetActive(true);

        isArriveCMScreen = false;
        while (isArriveCMScreen != true)
        {
            yield return null;
        }

        Navigation.SetActive(false);

        Texture.SetActive(true);
        Videos[13].SetActive(true);
        yield return new WaitForSecondsRealtime(22);
        Videos[13].SetActive(false);
        Texture.SetActive(false);

        while (gameManager.isClearMission1 != true) 
        {
            yield return null;
        }

        yield return new WaitForSeconds(10.0f);

        Texture.SetActive(true);
        Videos[14].SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        Videos[14].SetActive(false);
        Texture.SetActive(false);

        //Quest2Start

        while (isQuestStart2 != true)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
        Texture.SetActive(true);
        Videos[15].SetActive(true);
        yield return new WaitForSecondsRealtime(43.0f);
        Videos[15].SetActive(false);
        Texture.SetActive(false);

        while(gameManager.isClearMission2 != true)
        {
            yield return null;
        }

        //Mision2 Clear
        yield return new WaitForSeconds(10.0f);
        Texture.SetActive(true);
        Videos[16].SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        Videos[16].SetActive(false);
        Texture.SetActive(false);

        //Mission 3 Start
        while (isQuestStart3 != true)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
        Texture.SetActive(true);
        Videos[17].SetActive(true);
        yield return new WaitForSecondsRealtime(34.0f);
        Videos[17].SetActive(false);
        Texture.SetActive(false);

        while (gameManager.isClearMission3 != true)
        {
            yield return null;
        }

        // Mission 3 Clear
        yield return new WaitForSeconds(10.0f);
        Texture.SetActive(true);
        Videos[18].SetActive(true);
        yield return new WaitForSecondsRealtime(18.0f);
        Videos[18].SetActive(false);
        Texture.SetActive(false);
        SceneManager.LoadScene(2); 
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

    public void GrabRuneStone() { 
    
    isGrabRuneStone = true;
    
    }

    public void PlaceRuneStone() 
    {
        isPlaceRuneStone = true;

    }

    public void RunePlayButton() 
    { 
        isRunePLayButton = true;
    }

    public void QuestStart2()
    {
        isQuestStart2 = true;
    }

    public void QuestStart3()
    {
        isQuestStart3 = true;
    }


}
