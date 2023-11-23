using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    public int bulletDamage;
    [Range(0, 10f)] public float recoilAmount;
    public Rigidbody rb;
    private XRGrabInteractable interactable;
    public XRSocketInteractor socket;
    public GameObject socketObject, bulletCartridge;

    public float launchForce = 1.0f;

    private Vector3 bulletSpread = new Vector3(0.1f, 0.1f, 0.1f);

    public Transform cartridgeDischarge;

    public TrailRenderer bulletTrailPrefab;

    [Range(0, 999)] public int magazineSize;
    [Range(0, 10)] public int magazineAmount = 1;

    //private ObjectPool<TrailRenderer> TrailPool;

    private LayerMask Mask;

    // public ParticleSystem muzzleParticlele;

    public TMP_Text text_pro;

    private void Start(){
        socket = socketObject.GetComponent<XRSocketInteractor>();
        interactable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        interactable.onSelectEntered.AddListener(onPickUp);
        interactable.onSelectExited.AddListener(onDrop);

        interactable.onActivate.AddListener(onActive);
        interactable.onDeactivate.AddListener(onDeactive);

        text_pro = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateInfo(){
        if (magazineSize > 0 && socket.selectTarget != null){
            magazineSize--;
            text_pro.text = magazineSize.ToString();
        }
    }

    public void ResetMagazine(){
        magazineSize = 35;
        text_pro.text = magazineSize.ToString();
    }

    private void onPickUp(XRBaseInteractor interactor)
    {
        // Debug.Log("Object has been picked up");
    }

    private void onDrop(XRBaseInteractor interactor)
    {
        // Debug.Log("Object has been set down");
    }

    protected virtual void onActive(XRBaseInteractor interactor)
    {
        // Debug.Log("Trigger has been pressed");
    }

    protected virtual void onDeactive(XRBaseInteractor interactor)
    {
        // Debug.Log("Trigger has been released");
    }

    protected virtual void shootWeapon()
    {
        recoil();
    }

    private void recoil(){
        Debug.Log("Recoil!");
        rb.AddRelativeForce(Vector3.back * recoilAmount, ForceMode.Impulse);
    }
}
