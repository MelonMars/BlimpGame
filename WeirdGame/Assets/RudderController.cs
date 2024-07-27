using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderController : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float minRotationAngle = -90f;
    public float maxRotationAngle = 90f;

    private float currentRotationSpeed;
    private BlimpController blimpController;

    private void Start()
    {
        blimpController = transform.parent.GetComponent<BlimpController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, blimpController.rotationSpeed, Time.deltaTime);
        currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, minRotationAngle, maxRotationAngle);
        Quaternion targetRotation = Quaternion.Euler(0f, currentRotationSpeed, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
