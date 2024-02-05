using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnTrigger : MonoBehaviour
{
    public GameObject targetToAppear; // Assign this in the Inspector
    public float delayInSeconds = 1.0f; // Public delay time in seconds

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        // This assumes your player has been assigned the tag "Player" in Unity.
        if (other.CompareTag("Player"))
        {
            // Start the coroutine to activate the game object after a delay
            StartCoroutine(AppearAfterDelay());
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
