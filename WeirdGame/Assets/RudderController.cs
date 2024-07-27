using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderController : MonoBehaviour
{

    public float rotateSpeed = 30f;
    public float maxRotation = 45f;
    private float currentRotation = 0f;

    void Update()
    {
        float rotationInput = 0f;
        if (Input.GetAxis("Horizontal") > 0)
        {
            rotationInput += 1f;
        } else if (Input.GetAxis("Horizontal") < 0) {
            rotationInput -= 1f;
        }
        currentRotation += rotationInput * rotateSpeed * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(0f, currentRotation, 0f);
        if (Input.GetAxis("Horizontal") == 0) {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}

