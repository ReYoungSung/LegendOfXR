using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurorialVideoFlow : MonoBehaviour
{
    //interactions
    public bool isHenaUIClosed = false; 
    
    public bool isArrivePoster = false;
    
    public bool isPressPoster = false;

    public bool isGrabAvatar = false;
    public bool isArriveXRScreen = false;
    
    public bool isPlaceDownAvatar = false;

    public bool isPlaceRuneStone = false;

    public bool isArriveCameraController = false;

    public bool isChangingXRCameraPosition = false;

    [SerializeField] private GameObject[] Videos; 

    int HenaUIClickNum = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TutorialFlow());  
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

        isPressPoster = false;
        while ( isPressPoster != true ) 
        {
            yield return null;
        }
        Videos[3].SetActive(true);
        yield return new WaitForSecondsRealtime(20);
        Videos[3].SetActive(false);

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
