using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject objectToActivate;
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        // This assumes your player has been assigned the tag "Player" in Unity.
        if (other.CompareTag("Player"))
        {
            // Change the specified target game object
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                objectToActivate.gameObject.SetActive(true);
            }
        }
    }
}
