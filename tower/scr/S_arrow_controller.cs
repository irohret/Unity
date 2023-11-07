using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class S_arrow_controller : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowNew;

    [SerializeField]        
    private GameObject VisualNotch;

    [SerializeField] 
    private GameObject spawnPoint;


    private float launchForce = 1.5f; // You can adjust this value as needed


    // Used for the OnPull() Event
    public void PrepareArrow(){
        VisualNotch.SetActive(true);
    }
    
    // Used for the OnRelease() event
    public void ReleaseArrow(float strength){
        VisualNotch.SetActive(false);
        
        GameObject arrow = Instantiate(arrowNew);
        
        arrow.transform.position = spawnPoint.transform.position;

        Vector3 localBowForward = VisualNotch.transform.forward;

        // Calculate the local up vector of the arrow
        Vector3 localUp = -Vector3.Cross(localBowForward, Vector3.right);

        // Set the arrow's rotation to align its local up with the world's down direction
        arrow.transform.rotation = Quaternion.LookRotation(localBowForward, localUp);

        Rigidbody arrowRB = arrow.GetComponent<Rigidbody>();
        
        // Apply force to the arrow to launch it
        arrowRB.AddForce(localBowForward * launchForce * strength, ForceMode.Impulse);

    }
}
