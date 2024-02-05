using System.Collections;
using UnityEngine;

public class MensajeEnPantalla : MonoBehaviour
{
    public GameObject targetToAppear; // Assign this in the Inspector
    public float delayInSeconds = 1.0f; // Public delay time in seconds
    private bool hasAppeared = false; // Flag to check if the target has already appeared

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player and the target hasn't appeared yet
        if (other.CompareTag("Player") && !hasAppeared)
        {
            // Start the coroutine to activate the game object after a delay
            StartCoroutine(AppearAfterDelay());
            hasAppeared = true; // Set the flag to true to prevent future activation
        }
    }

    IEnumerator AppearAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Activate the specified game object
        if (targetToAppear != null)
        {
            targetToAppear.SetActive(true);
        }
    }
}
