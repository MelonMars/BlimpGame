using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float distance = 10.0f;
    public float rotationSpeed = 5.0f;
    public float minDistance = 1f;
    public float maxDistance = 30f;
    public float zoomSpeed = 30f;
    private float currentX = 0.0f;

    void Start()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position);
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position);
    }
}
