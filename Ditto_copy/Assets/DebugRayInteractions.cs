using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DebugRayInteractions : MonoBehaviour
{
    private XRBaseInteractor interactor;

    private void Start()
    {
        // Find the XRBaseInteractor component on this GameObject.
        interactor = GetComponent<XRBaseInteractor>();

        // Check if the interactor is not null.
        if (interactor != null)
        {
            // Subscribe to the OnSelectEntered event.
            interactor.selectEntered.AddListener(HandleSelectEntered);
        }
    }

    void Update()
    {
        if (interactor != null && interactor.selectTarget != null)
        {
            Debug.Log("Selected object: " + interactor.selectTarget.name);
        }
    }

    private void HandleSelectEntered(SelectEnterEventArgs args)
    {
        // Check if the ray hit something.
        if (args.interactable != null)
        {
            // Log information about the hit object.
            Debug.Log("Ray hit: " + args.interactable.name);
        }
        else
        {
            // Log a message indicating that the ray hit nothing.
            Debug.Log("Ray hit nothing.");
        }
    }
}
