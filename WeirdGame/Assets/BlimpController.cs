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
    [Range(0, 100)]
    public float maxStamina = 10f;



    public float speed;
    public float rotationSpeed;
    [SerializeField]
    private float privateLift;
    [SerializeField]
    public float privateStamina;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        privateStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle speed changes based on vertical input
        if (Input.GetAxis("Vertical") > 0)
        {
            speed += 1 * Time.deltaTime * acceleration;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speed -= 1 * Time.deltaTime * acceleration;
        }

        // Clamp speed within limits
        speed = Mathf.Clamp(speed, stallSpeed, topSpeed);

        // Handle lift based on speed
        if (speed < stallSpeed)
        {
            privateLift = 0;
        }
        else
        {
            privateLift = mainLift;
        }

        // Handle rotation based on horizontal input
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
                rotationSpeed -= speed * Time.deltaTime;
            }
            else if (rotationSpeed < 0)
            {
                rotationSpeed += speed * Time.deltaTime;
            }
        }

        // Clamp rotation speed within limits
        rotationSpeed = Mathf.Clamp(rotationSpeed, -maxRotationSpeed, maxRotationSpeed);

        // Handle stamina drain and regeneration
        if (speed == topSpeed)
        {
            privateStamina -= 1 * Time.deltaTime;
            if (privateStamina <= 0)
            {
                speed -= 1;
            }
        }
        else
        {
            privateStamina += 1 * Time.deltaTime;
        }

        // Ensure stamina stays within limits
        privateStamina = Mathf.Clamp(privateStamina, 0, maxStamina);

        // Handle vertical lift when space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && privateLift > 0)
        {
            privateLift = 15;
        }

        // Apply rotation to the blimp
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Calculate new velocity
        Vector3 newVelocity = transform.forward * speed;
        newVelocity.y += (privateLift - weight) * Time.deltaTime;

        // Apply the new velocity to the Rigidbody
        rb.velocity = newVelocity;
    }

}