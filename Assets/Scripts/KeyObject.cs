using UnityEngine;

public class KeyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Checks if the collider belongs to the player
        {
            AnimateOnPlayerContact.HasTheKey = true; // Player now has the key
            
        }
    }
}
