using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSpeed = 2000f;
    [SerializeField] private float upDownSpeed = 5f;

    private Vector3 moveDirection;

    void Update()
    {
        // Calculate movement direction based on WASD input
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // Move the camera based on movement direction and speed
        transform.position += moveDirection * movementSpeed * Time.deltaTime;

        // Move the camera up or down based on Q and E input
        float upDownDirection = Input.GetKey(KeyCode.Q) ? -1f : Input.GetKey(KeyCode.E) ? 1f : 0f;
        transform.position += Vector3.up * upDownDirection * upDownSpeed * Time.deltaTime;

        // Rotate the camera based on mouse click and drag
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Rotate around the Y axis based on horizontal mouse movement
            transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime, Space.World);

            // Rotate around the X axis based on vertical mouse movement
            transform.Rotate(Vector3.right, -mouseY * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}