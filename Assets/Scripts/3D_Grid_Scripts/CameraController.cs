using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 100f;
    public float verticalSpeed = 10f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reset position and rotation
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            return; // Skip the rest of this frame
        }

        if (Input.GetButton("Fire2"))
        {
            float yaw = turnSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
            float pitch = -turnSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

            transform.Rotate(pitch, yaw, 0, Space.Self);
        }

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float y = (Input.GetKey(KeyCode.E) ? 1 : 0) - (Input.GetKey(KeyCode.Q) ? 1 : 0);
        y *= Time.deltaTime * verticalSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Use LocalSpace for moving Forward, Backward and Strafing
        transform.Translate(new Vector3(x, y, z), Space.Self);
    }
}
