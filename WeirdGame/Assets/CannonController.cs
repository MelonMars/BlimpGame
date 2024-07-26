using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject shell;
    public float rotationSpeed = 10f;

    void Update()
    {
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward = Vector3.Scale(cameraForward, new Vector3(1, 0, 1));
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(shell);
            shot.transform.parent = transform;
        }
    }
}
