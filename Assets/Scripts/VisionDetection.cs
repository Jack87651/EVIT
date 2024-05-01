using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetection : MonoBehaviour
{
    public SecurityGuardController securityGuardController; // Reference to the security guard's controller
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player spotted! Security guard speed set to zero.");
            // Call the StopMovement method to set the guard's speed to zero
            securityGuardController.StopMovement();
            playerController.GetTazed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerController != null)
        {
            Debug.Log("Player has left the vision. Recovering from taze.");
            playerController.RecoverFromTaze();
        }
    }
}
