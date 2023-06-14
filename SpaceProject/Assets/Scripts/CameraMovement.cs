using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=MFQhpwc6cKE&ab_channel=Brackeys
public class CameraMovement : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Vector3 offset;

    [SerializeField] public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}