using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
public class S_GlockController : MonoBehaviour
{
    public Transform bulletSpawn, gun;

    public UnityEvent OnTriggerEvent, OnReleaseEvent;

    private XRGrabInteractable XRinteractable;

    private void Awake(){
        XRinteractable = gun.GetComponent<XRGrabInteractable>();
    }

    private void Start(){
        XRinteractable.selectEntered.AddListener(OnFire);
        XRinteractable.selectExited.AddListener(OnReset);
    }

     void OnReset(SelectExitEventArgs args){
        OnTriggerEvent?.Invoke();
    }
    
    private void OnFire(SelectEnterEventArgs args){
        OnReleaseEvent?.Invoke();
    }

    /*
    void OnReset(DeactivateEventArgs  args){
        OnTriggerEvent?.Invoke();
    }

    private void OnFire(ActivateEventArgs  args){
        OnReleaseEvent?.Invoke();
    }*/
    
}
