using UnityEngine;

public class SecurityGuardController : MonoBehaviour
{
    public float speed = 2.0f;         // Speed at which the guard moves
    public float patrolDistance = 50f; // Distance the guard will patrol back and forth
    public Animator animator;

    private Vector2 startPos;         // Starting position of the guard
    private bool movingRight = true;  // Direction of movement

    void Start()
    {
        startPos = transform.position; // Record the starting position
    }

    void Update()
    {
        if (speed > 0)
        {
            // Calculate current patrol distance from the start position
            float distFromStart = Vector2.Distance(startPos, transform.position);

            if (distFromStart >= patrolDistance)
            {
                movingRight = !movingRight;  // Change direction
                Flip(); // Flip the sprite when changing direction
            }

            if (movingRight)
            {
                // Move to the right
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                // Move to the left
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        }
    }

    public void StopMovement()
    {
        speed = 0; // Stop the guard by setting speed to zero
        animator.StopPlayback();
        Debug.Log("Should have stopped");
        animator.SetFloat("Speed", 0);
    }

    void Flip()
    {
        // Flip the sprite by multiplying the x component of the local scale by -1
        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        transform.localScale = flipped;
    }
}
