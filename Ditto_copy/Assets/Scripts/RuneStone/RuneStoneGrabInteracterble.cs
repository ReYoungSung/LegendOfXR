using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RuneStoneGrabInteracterble : XRGrabInteractable
{
    public enum RuneType
    {
        Rectangle,
        Triangle,   
        Circle
    }

    public RuneType runeType = RuneType.Rectangle;

    public bool isGrabbed = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isGrabbed = true;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
    }
}

