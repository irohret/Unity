using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class S_player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private CapsuleCollider CC;
   
    [SerializeField] private Transform orientation, player, playerOb;
    [SerializeField] private float mouseSpeedX = 5f;
    [SerializeField] private float mouseSpeedY = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    private Transform cameraMain;

    private bool followMouse = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CC = GetComponent<CapsuleCollider>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 view = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = view.normalized;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 inputDir = orientation.forward * moveY + orientation.right * moveX;

        if (followMouse && view != Vector3.zero)
        {
            playerOb.forward = Vector3.Slerp(playerOb.forward, view.normalized, Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            followMouse = !followMouse;
            Cursor.lockState = followMouse ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
