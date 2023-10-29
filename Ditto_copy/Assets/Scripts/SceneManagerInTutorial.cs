using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInTutorial : MonoBehaviour
{
    public GameObject TriggerObject;

    // Update is called once per frame
    void Update()
    {
        if(TriggerObject.activeSelf == false)
        {
            SceneManager.LoadScene(1);
        }
    }
}
