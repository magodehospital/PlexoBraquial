using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        // Update the camera's position to follow the player with the given offset
        transform.position = player.position + offset;
    }
}
