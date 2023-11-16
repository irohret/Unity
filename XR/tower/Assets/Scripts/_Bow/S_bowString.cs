using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class S_bowString : MonoBehaviour
{
    private LineRenderer bowString;

    [SerializeField]
    private Transform endPoint1, endPoint2;
    // private Vector3 midPosition;

    private void Awake() {
        bowString = GetComponent<LineRenderer>();
    }

     public void create_string(Vector3? midPos){
        Vector3[] linePoints = new Vector3[3];

        linePoints[0] = endPoint1.localPosition;

        if (midPos != null) {
            // Transform midPos into the local space of the bowString's parent
            linePoints[1] = transform.InverseTransformPoint(midPos.Value);
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

    private void Start(){
        // Call createString with null midPosition
        create_string(null);
    }
}
