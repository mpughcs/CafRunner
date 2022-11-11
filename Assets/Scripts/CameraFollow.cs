// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// CameraFollow Class
//This class controls the camera movement and uses the player as a target to
//to smoothly track and follow them

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public float followX = 0;
    public float followY = 5;


    void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(followX, followY,-10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

    

