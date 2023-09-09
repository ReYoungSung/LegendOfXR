using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterScaler : XRGrabInteractable
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    private float originalRotationX;
    private float originalRotationZ;

    public Vector3 originalScaleValue = Vector3.one;


    private void Start()
    {
        // Initialize the original scale with the provided value
        originalScale = originalScaleValue;
        targetScale = originalScale;

        originalRotationX = this.transform.localRotation.x;
        originalRotationZ = this.transform.localRotation.z;
    }

    private void Update()
    {
        // Check if the object is currently grabbed
        if (isSelected)
        {
            this.transform.localScale = originalScale;
        }
    }

    // protected override void OnSelectEntered(XRBaseInteractor interactor)
    // {
    //     this.transform.localScale = originalScale; // 크기를 30%로 줄입니다. 원하는 크기로 조절하세요.
    // }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        this.transform.localScale = originalScale * 3; // 최종 크기를 원래 크기로 설정
        this.transform.localRotation = Quaternion.Euler(originalRotationX, this.transform.localRotation.eulerAngles.y, originalRotationZ);
    }
}
