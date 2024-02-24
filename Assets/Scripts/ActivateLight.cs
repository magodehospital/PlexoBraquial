using UnityEngine;
using System.Collections;

public class ActivateLight : MonoBehaviour
{
    public Light targetLight; // Renamed from 'light' to 'targetLight'
    [SerializeField] private float delay = 1f;

    private void OnTriggerEnter(Collider other)
{
    // Check if the collider belongs to the player and if there is at least 1 EnergyCell
    if (other.CompareTag("Player") )
    {
        StartCoroutine(ActivateLightAfterDelay());
        
    }
}


    IEnumerator ActivateLightAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        targetLight.enabled = true; // Use the renamed field here
    }

    
}
