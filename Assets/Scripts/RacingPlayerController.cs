using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingPlayerController : MonoBehaviour
{
    public float acceleration = 30f;
    public float maxSpeed = 50f;
    public float turnSpeed = 100f;
    public float drag = 5f;
    public float brakeForce = 10f;

    private Rigidbody rb;
    private float currentSpeed = 0f;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag; // Helps with gradual stopping
    }

    void Update()
    {
        // Get input for acceleration & braking
        float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow
        turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow

        if (moveInput > 0) // Accelerate
        {
            currentSpeed += acceleration * moveInput * Time.deltaTime;
        }
        else if (moveInput < 0) // Braking
        {
            currentSpeed -= brakeForce * Time.deltaTime;
        }
        else // Natural slow down
        {
            currentSpeed -= acceleration * 0.5f * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    void FixedUpdate()
    {
        // Move forward in the direction of the object
        rb.velocity = transform.forward * currentSpeed;

        // Steering
        if (currentSpeed > 1f) // Prevent turning when stopped
        {
            transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        }
    }
}
