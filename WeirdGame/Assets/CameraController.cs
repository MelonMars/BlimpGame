using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public Transform target;
    public string vertMove = "C";
    public string freeMove = ".";

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, transform.up, -Input.GetAxis("Mouse X") * rotationSpeed);
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), vertMove, true)))
        {
            transform.RotateAround(target.position, transform.right, -Input.GetAxis("Mouse Y") * rotationSpeed);
        }
    }
}
