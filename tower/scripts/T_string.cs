using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(LineRenderer))]
public class T_string : MonoBehaviour {
    [SerializeField]
    private Transform endPoint1, endPoint2;

    private LineRenderer bowString;

    public Transform grab_object, notch, parent;
    public float pullAmount = 1.5f;
    private XRGrabInteractable XRinteractable;



    public  S_arrow_controller arrow;

    [SerializeField]
    private float speed = 10;



    private void Awake(){
        bowString = GetComponent<LineRenderer>();
        XRinteractable = grab_object.GetComponent<XRGrabInteractable>();
    }

     public void create_string(Vector3? midPos){
        int numPoints = midPos == null ? 2 : 3;
        Vector3[] linePoints = new Vector3[3];

        linePoints[0] = endPoint1.localPosition;

        if (midPos != null) {
            // Transform midPos into the local space of the bowString's parent
            linePoints[1] = transform.parent.InverseTransformPoint(midPos.Value);
        }

        linePoints[2] = endPoint2.localPosition;

        bowString.positionCount = linePoints.Length;
        bowString.SetPositions(linePoints);
    }

    public void ResetString(){
        // Reset the bowstring when released
        Vector3[] linePoints = new Vector3[2];
        linePoints[0] = Vector3.zero;
        linePoints[1] = Vector3.zero;
        bowString.positionCount = 2;
        bowString.SetPositions(linePoints);
    }

    void Reset(){
        grab_object.localPosition = Vector3.zero;
        notch.localPosition = Vector3.zero;
        ResetString();
    }

    /// <summary>
    /// if the grab object is not being seleted just show the normal bow string line rendere
    /// if the grab object is being  seletecd than recalulate the bow string rendere and hind the normal o
    /// </summary>

    void Update(){
        if(!XRinteractable.isSelected){
            OnRelease();
            create_string(null);
        } else{
            // XRinteractable.isSelected is true
            
            if(XRinteractable.isSelected){
                Vector3 midPoint_space = parent.InverseTransformPoint(grab_object.position);
                float abs = Mathf.Abs(midPoint_space.z);

                OnPull(abs, midPoint_space);               
                create_string(notch.position);
            } else {
                create_string(null);
                OnRelease();
            }
        }
    }

    void OnPull(float abs, Vector3 midPoint_space){
        if (midPoint_space.z < 0 && abs < pullAmount){

            arrow.getArrow();
            arrow.transform.position = notch.position;
            arrow.transform.rotation = notch.rotation;

            Vector3 launchDirection = notch.forward;

            arrow.arrowRB.AddForce(launchDirection * speed, ForceMode.Impulse);
            notch.localPosition = new Vector3(0, 0, midPoint_space.z);
        }
    }

    void OnRelease(){
        Reset();
    }
}