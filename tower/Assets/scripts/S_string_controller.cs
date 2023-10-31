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

    // private bool ready = false;
    public float pullAmount = 1.5f;

    private XRGrabInteractable XRinteractable;

    public Transform endPoint1, endPoint2;
    
    void Awake(){
        XRinteractable = grab_object.GetComponent<XRGrabInteractable>();
        // bowString.create_string(null);
    }

    private void Start(){
        bowString.ResetString();
    }

    void Reset()
    {
       //  bowString.create_string(null);
        grab_object.localPosition = Vector3.zero;
        notch.localPosition = Vector3.zero;
        bowString.ResetString();
        // bowString.create_string_2(notch, endPoint1, endPoint2);
    }

    /*
    void Update()
    {
        if (!ready)
        {
            Vector3 midPoint_space = parent.InverseTransformPoint(grab_object.position);
            float abs = Mathf.Abs(midPoint_space.z);

            OnRelease(midPoint_space);

            OnPull(abs, midPoint_space);
            bowString.create_string(notch.position); 
        }
    }*/


    void Update()
    {
        bowString.create_string(null);
        if (XRinteractable.isSelected)
        {
            Vector3 midPoint_space = parent.InverseTransformPoint(grab_object.position);
            float abs = Mathf.Abs(midPoint_space.z);

            OnPull(abs, midPoint_space);
            // bowString.create_string_2(midPoint_space, endPoint1, endPoint2);
            bowString.create_string(notch.position);
        } else {
            // bowString.ResetString();
            OnRelease();
        }
    }


    void OnPull(float abs, Vector3 midPoint_space)
    {
        if (midPoint_space.z < 0 && abs < pullAmount)
        {
            notch.localPosition = new Vector3(0, 0, midPoint_space.z);
        }
    }


    void OnRelease()
    {
        Reset();
    }
}