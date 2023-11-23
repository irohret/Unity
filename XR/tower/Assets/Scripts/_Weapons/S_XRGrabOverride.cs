using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class S_XRGrabOverride : XRSocketInteractor
{
    public string target;

    public override bool CanSelect(XRBaseInteractable interactable){
        return base.CanSelect(interactable) && interactable.CompareTag(target);
    }
}
