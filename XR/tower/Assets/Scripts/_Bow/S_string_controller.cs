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

    // Assign the grab_object, notch, and parent in the Inspector
    public Transform grab_object, notch, parent, BOW;
    [SerializeField] private float maxPullAmount = 0.05f;

    private XRGrabInteractable XRinteractable;
    private bool isPulling = false;

    private float strength;
    public UnityEvent <float> onReleaseEvent;
    public UnityEvent onPullEvent;

    private void Awake(){
        isPulling = false;
        XRinteractable = grab_object.GetComponent<XRGrabInteractable>();
    }

    private void OnGrab(SelectEnterEventArgs args){
        isPulling = true;
        bowString.create_string(notch.position);
    }

    private void OnRelease(SelectExitEventArgs  args){
        onReleaseEvent?.Invoke(strength);
        isPulling = false;
        Reset();
        bowString.create_string(null);
    }

    private void Start(){
        XRinteractable.selectEntered.AddListener(OnGrab);
        XRinteractable.selectExited.AddListener(OnRelease);
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

    // LinearScaler() is used to map the pullDistance value
    // from the range of [0, maxDistance] to the range of [0, 1].
    private float LinearScaler(float value, float fromMax, float toMax){
        return value / fromMax * toMax;
    }

    // Sigmoid() maps an input value to a value between 0 and 1, [0, 1].
    private float Sigmoid(float value){
        return Mathf.Clamp01(1f / (1f + Mathf.Exp(-value)));
    }

    private float CalculatePullDistance(Vector3 midPoint_space){
        float maxDistance = 0.5f;
        if (midPoint_space.z < 0) {
            strength = Mathf.Clamp(Mathf.Abs(midPoint_space.z), 0, maxDistance);
            // set launch to 0.75
            // return Sigmoid(strength);

            // set launch to 10
            return LinearScaler(strength, maxDistance, 1f);
        }
        return 0;
    }

    private void OnPull(float abs, Vector3 midPoint_space) {
        float pullAmount = -Mathf.Clamp(Mathf.Abs(midPoint_space.z), 0f, maxPullAmount);
       //  XRGrabInteractable bowGrabInteractable = BOW.GetComponent<XRGrabInteractable>();

        //if (midPoint_space.z < 0 && XRinteractable.selectingInteractor) {
        if (midPoint_space.z < 0 ) {
            strength = CalculatePullDistance(midPoint_space);

            // Debug.Log("pullAmount : " + pullAmount);

            notch.localPosition = new Vector3(0, 0, pullAmount);
            onPullEvent?.Invoke();

            bowString.create_string(notch.position);
        }
    }

    private void Reset(){
        strength = 0;
        grab_object.localPosition = Vector3.zero;
        // grab_object.position = Vector3.zero;
        notch.localPosition = Vector3.zero;
        bowString.ResetString();
    }
}
