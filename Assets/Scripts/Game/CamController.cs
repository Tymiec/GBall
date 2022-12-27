using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public static Controller Singleton;
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 3, -10);

    void FixedUpdate()
    {
        var pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        // assign the position of the player to the camera and add the offset and smooth it
        transform.position = Vector3.Lerp(transform.position, pos + offset, smoothSpeed);
    }
}
