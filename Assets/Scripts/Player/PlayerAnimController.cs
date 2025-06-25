using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    float speed = 0f;
    Vector3 lastPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = player.transform.position; // Initialize last position
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = player.transform.position; // Get the current position of the player
        currentPosition.y = 0; // Ignore vertical position for speed calculation
        speed = Vector3.Distance(currentPosition, lastPosition) / Time.deltaTime; // Calculate speed based on distance traveled since last frame
        lastPosition = currentPosition; // Update last position for next frame
        animator = player.GetComponent<Animator>(); // Get the Animator component from the player GameObject
        animator.SetFloat("Speed", speed); // Set the "Speed" parameter in the Animator to control animations based on speed
    }
}
