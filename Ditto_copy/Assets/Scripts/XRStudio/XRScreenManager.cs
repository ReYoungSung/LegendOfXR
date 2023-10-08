using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject XRCM;
    [SerializeField] private Transform Mission1Transform;
    [SerializeField] private Transform Mission2Transform;
    [SerializeField] private Transform Mission3Transform;

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            XRCM.transform.position = Mission1Transform.position;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            XRCM.transform.position = Mission2Transform.position;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            XRCM.transform.position = Mission3Transform.position;
        }
    }
}
