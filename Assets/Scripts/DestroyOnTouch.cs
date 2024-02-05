using UnityEngine;

public class DestroyTargetOnTouch : MonoBehaviour
{
    public GameObject targetToDestroy; // Assign this in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        // This assumes your player has been assigned the tag "Player" in Unity.
        if (other.CompareTag("Player"))
        {
            // Destroy the specified target game object
            if (targetToDestroy != null)
            {
                Destroy(targetToDestroy);
            }
            else
            {
                // If no target is specified, destroy this game object
                Destroy(gameObject);
            }
        }
    }
}
