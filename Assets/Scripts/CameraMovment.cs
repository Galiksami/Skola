using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public Transform target;
    public float followDistance = 8f;
    public float cameraSpeed = 3f;

    private void LateUpdate()
    {
        float newrotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * cameraSpeed;
        float newrotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * cameraSpeed;

        Vector3 desiredRotation = new Vector3(newrotationY, newrotationX, 0f);
        transform.localEulerAngles = desiredRotation;

        Vector3 desiredPosition = target.position - transform.forward * followDistance;
        transform.position = desiredPosition;
        
    }
}
