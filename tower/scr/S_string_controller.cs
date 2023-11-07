using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class S_string_controller : MonoBehaviour
{
    public S_bowString bowString; // Assign your bow string script
    public Transform grab_object, notch, parent; // Assign the grab_object, notch, and parent in the Inspector
    public float pullAmount = 1.5f;

    private XRGrabInteractable XRinteractable;
    private bool isPulling = false;

    public UnityEvent onPullEvent, onReleaseEvent;

    private void Awake(){
        XRinteractable = grab_object.GetComponent<XRGrabInteractable>();
    }

    private void Start(){
        XRinteractable.selectEntered.AddListener(OnGrab);
        XRinteractable.selectExited.AddListener(OnRelease);
        bowString.create_string(null);
    }

    private void OnGrab(SelectEnterEventArgs args){
        isPulling = true;
        bowString.create_string(notch.position);
    }

    private void OnRelease(SelectExitEventArgs  args){
        isPulling = false;
        Reset();
        bowString.create_string(null);
    }

    private void Update(){
        if (isPulling){
            Vector3 midPoint_space = parent.InverseTransformPoint(grab_object.position);
            float abs = Mathf.Abs(midPoint_space.z);
            OnPull(abs, midPoint_space);
            bowString.create_string(notch.position);
        }
    }

    private void OnPull(float abs, Vector3 midPoint_space) {
        if (midPoint_space.z < 0 && abs < pullAmount) {
            notch.localPosition = new Vector3(0, 0, midPoint_space.z);
            onPullEvent?.Invoke();
        }
    }

    private void Reset(){
        grab_object.localPosition = Vector3.zero;
        notch.localPosition = Vector3.zero;
        bowString.ResetString();
        onReleaseEvent?.Invoke();
    }
}