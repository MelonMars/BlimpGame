using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BlimpController : MonoBehaviour
{
    [Range(0f, 100f)]
    public float mainLift = 5f;
    [Range(0f, 10000f)]
    public float topSpeed = 10f;
    [Range(-10f, 10f)]
    public float stallSpeed = 5f;
    [Range(1f, 10f)]
    public float acceleration = 3f;
    public float weight = 5f;
    [Range(0, 360)]
    public float maxRotationSpeed;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float privateLift;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            speed += 1 * Time.deltaTime * acceleration;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speed -= 1 * Time.deltaTime * acceleration;
        }
        if (speed > topSpeed)
        {
            speed = topSpeed;
        }
        else if (speed < stallSpeed)
        {
            privateLift = 0;
        }
        else
        {
            privateLift = mainLift;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rotationSpeed += speed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rotationSpeed -= speed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            if (rotationSpeed > 0)
            {
                rotationSpeed -= speed;
            }
            else if (rotationSpeed < 0)
            {
                rotationSpeed += speed;
            }
            if (rotationSpeed > maxRotationSpeed)
            {
                rotationSpeed = maxRotationSpeed;
            }
            else if (rotationSpeed < -maxRotationSpeed)
            {
                rotationSpeed = -maxRotationSpeed;
            this.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            rb.velocity = transform.forward * speed;
            rb.velocity += new Vector3(0, (privateLift-weight) * Time.deltaTime, 0);
        }
    }
}