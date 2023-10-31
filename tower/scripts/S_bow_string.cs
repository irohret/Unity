using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(LineRenderer))]
public class S_bow_string : MonoBehaviour
{
    public Transform start, end;
    private LineRenderer _lineRenderer;
    public GameObject notch;
    public float pull_amount { get; private set; } = 0.0f;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void OnRelease()
    {
        pull_amount = 0f;
        notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, 0f);
        UpdateString();
    }

    public void OnPull()
    {
        // Calculate the midpoint
        float midpoint = (_lineRenderer.GetPosition(0).z + _lineRenderer.GetPosition(2).z) / 2;

        // Calculate the pull position based on the midpoint
        Vector3 pullPosition = new Vector3(start.position.x, start.position.y, midpoint);
        pull_amount = CalcPull(pullPosition);
        UpdateString();
    }

    private void UpdateString()
    {
        Vector3 linePosition = Vector3.forward * Mathf.Lerp(0, end.transform.localPosition.z - start.transform.localPosition.z, pull_amount);
        _lineRenderer.SetPosition(1, start.position + linePosition);
    }

    private float CalcPull(Vector3 pullPosition)
    {
        Vector3 pull_direction = pullPosition - start.position;
        Vector3 target_direction = end.position - start.position;
        return Mathf.Clamp01(Vector3.Dot(pull_direction, target_direction) / target_direction.sqrMagnitude);
    }
}
