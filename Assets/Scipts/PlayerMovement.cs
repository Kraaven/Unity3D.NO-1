using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float maxSpeed = 10f;
    public float jumpSpeed = 8f;

    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get player input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction and velocity
        Vector3 movement = transform.forward * moveVertical * speed + transform.right * moveHorizontal * speed;
        Vector3 newVelocity = rb.velocity;

        // Apply movement to the rigidbody, while preserving the vertical component
        newVelocity.x = movement.x;
        newVelocity.z = movement.z;

        // Limit the magnitude of the velocity to cap the speed
        if (newVelocity.magnitude > maxSpeed)
        {
            newVelocity = newVelocity.normalized * maxSpeed;
        }

        rb.velocity = newVelocity;

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity += new Vector3(0, jumpSpeed, 0);
        }

        // Unlock cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    bool IsGrounded()
    {
        // Perform a simple raycast downward to check if the player is grounded
        float raycastDistance = 1.1f;
        Debug.Log(Physics.Raycast(transform.position, Vector3.down, raycastDistance, LayerMask.GetMask("Ground")));
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance, 1);
    }
}