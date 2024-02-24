using UnityEngine;
using TMPro; // Required for working with TextMeshPro elements

public class ItemCollector : MonoBehaviour
{
    public static int itemCount = 0; // Counter for the items collected
    public TextMeshProUGUI itemCountText; // Reference to the TextMeshPro UI component that displays the item count
    public string textToDisplay;
    public string collectibleTag; // Use this in the Inspector to specify what tag is considered collectible, e.g., "EnergyCell"
    

    private void Start()
    {
        UpdateItemCountText(); // Initialize the UI text on start
    }

    private void Update ()
    {
         itemCountText.text = textToDisplay + itemCount.ToString(); // Update the UI text to reflect the number of items collected
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the specified collectible tag
        if (other.gameObject.CompareTag(collectibleTag))
        {
            itemCount++; // Increase the item count
            UpdateItemCountText(); // Update the UI text to show the current item count
            Destroy(other.gameObject); // Remove the collected item from the scene

           
        }
    }

    void UpdateItemCountText()
    {
        itemCountText.text = textToDisplay + itemCount.ToString(); // Update the UI text to reflect the number of items collected
    }
}
