using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;        // Reference to the player's transform
    public float damping = 0;    // Damping effect for smooth camera movement
    public Vector2 offset = new Vector2(0f, 0f);  // Offset from the player position

    private Vector3 velocity = Vector3.zero; // Needed for the SmoothDamp function
    private float originalZ;                 // To maintain the camera's original Z position

    private void Start()
    {
        originalZ = transform.position.z;   // Store the original z position of the camera
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(
                player.position.x + offset.x,
                player.position.y + offset.y,
                originalZ);

            // Use SmoothDamp instead of Lerp for a smoother transition
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
        }
    }
}
