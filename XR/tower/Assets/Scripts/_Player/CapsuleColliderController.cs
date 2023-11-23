using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class CapsuleColliderController : MonoBehaviour
{
    
    public XROrigin m_XROrigin;
    public float m_MinHeight, m_MaxHeight;

    public CapsuleCollider collider;

    // Update is called once per frame
    void Update()
    {
        if (m_XROrigin == null || collider == null)
                return;

        var height = Mathf.Clamp(m_XROrigin.CameraInOriginSpaceHeight, m_MinHeight, m_MaxHeight);

        Vector3 center = m_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + collider.radius;

        collider.height = height;
        collider.center = center;
        
    }
}
