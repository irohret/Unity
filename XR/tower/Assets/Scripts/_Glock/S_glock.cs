using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]

public class S_glock : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public Transform spawn;
    private float launchForce = 25f;

    private XRBaseInteractable interactable;

    // Contains the socket interactor
    // this script is attacted to the magagize gameObject;
    // S_XRGrabOverride grab; 

    private XRSocketInteractor socket;

    private Rigidbody rb;

    public GameObject socketObject;


    public float recoil = 0.5f;

    private async void Start()
    {
        
        socket = socketObject.GetComponent<XRSocketInteractor>();
        
        interactable = GetComponent<XRBaseInteractable>();
        rb = GetComponent<Rigidbody>();
        socket.onSelectEntered.AddListener(OnSelectEntered);
        socket.onSelectExited.AddListener(OnSelectExited);

        interactable.onActivate.AddListener(OnActivate);
        interactable.onDeactivate.AddListener(OnDeactivate);

    }

    private void OnSelectEntered(XRBaseInteractable interactable){

    }

    private void OnSelectExited(XRBaseInteractable interactable){

    }

    private void OnDeactivate(XRBaseInteractor interactor){
        Debug.Log("Object stop");
    }


    private void OnActivate(XRBaseInteractor interactor){
        // Check if there is an object inside the socket
        if (socketObject != null){
            fire();
            onRecoil();
        } else {    
            Debug.Log("No object inside the socket. Cannot fire.");
        }
    }

    private void fire(){
        // Check if there is a selected target in the socket interactor
    
        if (socket != null && socket.selectTarget != null) {
            GameObject bullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = launchForce * spawn.forward;
            onRecoil();
            Destroy(bullet, 5f);
        } else {
            Debug.Log("No magazine in the socket interactor. Cannot fire.");
        }
    }


    private void onRecoil(){
        rb.AddRelativeForce(Vector3.back * recoil, ForceMode.Impulse);
    }
}
