using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    public float velocity = 10f;
    private Transform parent;
    private Rigidbody rb;

    private void Awake()
    {
        parent = transform.parent;
        transform.forward = parent.transform.forward;
    }

    void Update()
    {
        rb.velocity = transform.forward * velocity;
    }
}
