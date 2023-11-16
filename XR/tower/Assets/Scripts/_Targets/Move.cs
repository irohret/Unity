
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public Vector3 pos1 = new Vector3(-4, 0, 0);
    public Vector3 pos2 = new Vector3(4, 0, 0);
    public float speed = 1.0f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        //transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime, Space.World);
    }
}
