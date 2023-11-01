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
    void Awake(){
        XRinteractable = grab_object.GetComponent<XRGrabInteractable>();
    }

    private void Start(){
        bowString.ResetString();
    }

    void Reset() {
        grab_object.localPosition = Vector3.zero;
        notch.localPosition = Vector3.zero;
        bowString.ResetString();
    }

    void Update(){
        if(!XRinteractable.isSelected){
            OnRelease();
            bowString.create_string(null);
        } else{
            // XRinteractable.isSelected is true
            if(XRinteractable.isSelected){
                Vector3 midPoint_space = parent.InverseTransformPoint(grab_object.position);
                float abs = Mathf.Abs(midPoint_space.z);

                OnPull(abs, midPoint_space);               
                bowString.create_string(notch.position);
            } else {
                bowString.create_string(null);
                OnRelease();
            }
        }
    }

    void OnPull(float abs, Vector3 midPoint_space) {
        if (midPoint_space.z < 0 && abs < pullAmount) {
            notch.localPosition = new Vector3(0, 0, midPoint_space.z);
        }
    }

    void OnRelease() {
        Reset();
    }
}