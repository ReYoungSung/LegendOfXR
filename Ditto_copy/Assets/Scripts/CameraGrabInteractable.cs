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

    public AudioClip clip;
    public GameObject XRCameraUI;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.enabled = true;
        XRCamera.enabled = false;
        // Close UI beforehand;
        XRCameraUI.SetActive(false);
        
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {

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
        //PUT SOUND AND UI FOR CAM
        XRCameraUI.SetActive(true);

        if (clip)
        {
		    AudioSource.PlayClipAtPoint(clip,Vector3.zero); 
        }

        firstPersonCamera.enabled = false;
          XRCamera.enabled = true;
    }

    public void ChangeViewToFirstPersonCM()
    {
        XRCameraUI.SetActive(false);
        firstPersonCamera.enabled = true;
        XRCamera.enabled = false;
    }
}
