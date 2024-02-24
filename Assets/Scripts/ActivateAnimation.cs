using UnityEngine;

public class AnimateOnPlayerContact : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    [SerializeField] private string animatorBoolName;
    [SerializeField] private float delay = 1f;

    // Static property to track if the player has the key
    public static bool HasTheKey { get; set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && HasTheKey) // Checks if the player has the key
        {
            myAnimationController.SetBool(animatorBoolName, true); // Activates the animation
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Optional: Resets the animation when the player exits the collider
        {
            myAnimationController.SetBool(animatorBoolName, false); // Deactivates the animation
        }
    }*/
}
