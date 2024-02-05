using UnityEngine;
using TMPro; // Required for working with TextMeshPro elements

public class ItemCollector : MonoBehaviour
{
    
    private int itemCount = 0; // Counter for the items collected
    public TextMeshProUGUI itemCountText; // Reference to the TextMeshPro UI component that displays the item count
    public string textToDisplay;
    public string collectibleTag;

    private void Start()
    {
        UpdateItemCountText(); // Initialize the UI text on start
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag 'Collectible'
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
