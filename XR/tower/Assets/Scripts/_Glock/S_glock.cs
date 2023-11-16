using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_glock : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public Transform spawn;
    private float launchForce = 25f;

    private XRBaseInteractable interactable;

    // Contains the socket interactor
    // this script is attacted to the magagize gameObject;
    // S_XRGrabOverride grab; 


     XRSocketInteractor socket;

    private bool canFire = false;

    private void Start()
    {
        canFire = false;
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onSelectEntered.AddListener(OnSelectEntered);
        interactable.activated.AddListener(OnActivated);

        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // Object has been accepted by an XR interactor
        Debug.Log("Object has been accepted by an XR interactor");

        // iff when the object is accepted can we use the trigger to fire the weapon
        canFire = true;
        // fire();
    }

    private void OnActivated(ActivateEventArgs args)
    {
         Debug.Log(socket.hasSelection);
        if(canFire){
            fire();
        }
       Debug.Log("OnActivated");
    }


    private void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = launchForce * spawn.forward;
        Destroy(bullet, 5f);
    }
}
