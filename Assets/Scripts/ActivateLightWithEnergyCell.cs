using UnityEngine;
using System.Collections;

public class ActivateLightWithEnergyCell : MonoBehaviour
{
    public Light targetLight; // The light to activate
    [SerializeField] private float delay = 1f; // Delay before the light turns on
    private static int energyCellCount = 0; // Tracks the number of EnergyCells

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ItemCollector.itemCount >= 1)
        {
            StartCoroutine(ActivateLightAfterDelay());
            ItemCollector.itemCount--; // Use an EnergyCell
        }
    }

    IEnumerator ActivateLightAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        targetLight.enabled = true; // Turn on the light
    }
}
