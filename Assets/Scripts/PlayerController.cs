using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.05f;  // Speed of the player
    public Rigidbody2D rb;     // Reference to the Rigidbody2D component
    public Animator animator;
    private Vector2 moveVelocity; // Store movement velocity
    public float crouchSpeedReduction = 0.5f; // Speed reduction factor when crouching
    private bool isCrouching = false; // Is the player crouching?
    private Vector3 originalScale; // Store the original scale
    public bool Tazed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        originalScale = transform.localScale; // Save the original scale
    }

    void Update()
    {
        // Check for crouch input
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isCrouching = true;
            Crouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouching = false;
            StandUp();
        }

        // Input handling for movement
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float currentSpeed = isCrouching ? speed * crouchSpeedReduction : speed;
        moveVelocity = moveInput.normalized * currentSpeed;
    }

    void FixedUpdate()
    {
        // Move the player every physics frame
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        animator.SetFloat("Speed", moveVelocity.magnitude);
    }

    public void GetTazed()
    {
        Tazed = true;
        animator.SetBool("Tazed", true);
        // Add any additional reactions, such as playing an animation or stopping movement
    }

    public void RecoverFromTaze()
    {
        Tazed = false;
        animator.SetBool("Tazed", false);
        // Recovery logic or resetting conditions
    }

    void Crouch()
    {
        transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);
    }

    void StandUp()
    {
        transform.localScale = originalScale;
    }
}
