using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 _cameraOffset;

    [Range(5.0f, 5.0f)]
    public float SmoothFactor = 0.5f;

    // will check that the camera look at the target or not
    public bool lookAtTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Vector3 newPosition = PlayerTransform.transform.position + _cameraOffset;
        // transform.position = newPosition;

        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        

        // Camera Rotation change
        if (lookAtTarget) {
            transform.LookAt(PlayerTransform);
        }
    }
}
