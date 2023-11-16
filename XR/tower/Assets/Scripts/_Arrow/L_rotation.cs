using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_rotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float rotationSpeed = 5f;

    private void FixedUpdate()
    {
        transform.forward =
            Vector3.Slerp(transform.forward, rb.velocity.normalized, rotationSpeed * Time.fixedDeltaTime);
        // Quaternion targetRotation = Quaternion.LookRotation(rb.velocity.normalized, Vector3.up);
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        
    }

}
