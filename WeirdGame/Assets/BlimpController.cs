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

        speed = Mathf.Clamp(speed, 0, topSpeed);

        if (speed < stallSpeed)
        {
            privateLift = -weight; 
        }
        else
        {
            privateLift = mainLift - weight;
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
            rotationSpeed = Mathf.Lerp(rotationSpeed, 0, Time.deltaTime * acceleration);
        }

        rotationSpeed = Mathf.Clamp(rotationSpeed, -maxRotationSpeed, maxRotationSpeed);

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

        privateStamina = Mathf.Clamp(privateStamina, 0, maxStamina);

        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        Vector3 newVelocity = transform.forward * speed;

        if (Input.GetKey(KeyCode.Space) && privateStamina > 0)
        {
            newVelocity.y = privateLift + 15f;
        }
        else
        {
            newVelocity.y = privateLift; 
        }

        rb.velocity = newVelocity;

        Debug.Log("Speed: " + speed);
        Debug.Log("Rotation Speed: " + rotationSpeed);
        Debug.Log("Private Lift: " + privateLift);
        Debug.Log("Velocity: " + newVelocity);
    }
}
