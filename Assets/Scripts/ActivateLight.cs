using UnityEngine;

public class ActivateLight : MonoBehaviour
{
    public Light light; // Reference to the light you want to turn on

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        // This assumes your player has been assigned the tag "Player" in Unity.
        if (other.CompareTag("Player"))
        {
            // Turn on the light
            light.enabled = true;
        }
    }
}
