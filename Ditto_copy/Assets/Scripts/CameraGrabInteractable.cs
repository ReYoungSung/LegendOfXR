using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraGrabInteractable : XRGrabInteractable
{
    public Camera firstPersonCamera;
    public Camera XRCamera;

    public Transform left_grab_transform;
    public Transform right_grab_transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        Debug.Log("잡았다!!");

        if(interactor.CompareTag("RightHand"))
        {
            this.attachTransform = right_grab_transform;
        }
        else if(interactor.CompareTag("LeftHand"))
        {
            this.attachTransform = left_grab_transform;
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        
    }

    protected override void OnActivate(XRBaseInteractor interactor)
    {
        ChangeViewToXRCM();
    }

    protected override void OnDeactivate(XRBaseInteractor interactor)
    {
        ChangeViewToFirstPersonCM();
    }

    public void ChangeViewToXRCM()
    {
        Debug.Log("바꿨다!!");
        firstPersonCamera.enabled = false;
        XRCamera.enabled = true;
    }

    public void ChangeViewToFirstPersonCM()
    {
        firstPersonCamera.enabled = true;
        XRCamera.enabled = false;
    }
}
