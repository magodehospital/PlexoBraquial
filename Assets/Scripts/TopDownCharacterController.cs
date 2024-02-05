using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float rotationSpeed = 360f; // Degrees per second
    public float slowMoveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;
    private Animator animator;
    private float variableMoveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Get the Animator component
        variableMoveSpeed = moveSpeed;
    }

    void Update()
    {
        // Input for movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveX, 0f, moveZ).normalized;

        // Set the animation
        bool isMoving = movement.magnitude > 0;
        animator.SetBool("isRunning", isMoving);

        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
         // Raycast downward to check the ground angle
    RaycastHit hit;
    if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
    {
        float angle = Vector3.Angle(hit.normal, Vector3.up);
        if (angle < 45) // 45 degrees threshold
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    }

    void FixedUpdate()
    {
        // Move the character
        if (movement.magnitude > 0.1f) // Ensure there is noticeable movement
        {
            rb.MovePosition(rb.position + movement * variableMoveSpeed * Time.fixedDeltaTime);

            // Rotate the character to face the direction of movement
            RotateCharacter();
        }
    }

    private void RotateCharacter()
    {
        if (movement != Vector3.zero)
        {
            // Create a target rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            // Smoothly rotate towards the target rotation
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Check if the player has collided with the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("SlowZone"))
        {
            variableMoveSpeed = slowMoveSpeed;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        variableMoveSpeed = moveSpeed;   
    }
}
