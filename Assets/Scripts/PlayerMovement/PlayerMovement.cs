using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    InputSystem_Actions inputActions; // Reference to the input actions class

    public Transform playerBody;
    public Camera playerCamera; // Reference to the player's camera
    public float mouseSensitivity = 100f; // Sensitivity for mouse movement
    public CharacterController characterController; // Reference to the CharacterController components
    float xRotation = 0f; // Variable to store the vertical rotation of the player
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        inputActions = new InputSystem_Actions(); // Initialize the input actions
        inputActions.Player.Enable(); // Enable the input actions to start receiving input events
    }

    void Update()
    {
        float MouseX = inputActions.Player.Look.ReadValue<Vector2>().x; // Read the mouse X input value
        float MouseY = inputActions.Player.Look.ReadValue<Vector2>().y; // Read the mouse Y input value
        Vector2 MoveValue = inputActions.Player.Move.ReadValue<Vector2>(); // Read the movement input value

        xRotation -= MouseY * Time.deltaTime * mouseSensitivity; // Adjust the vertical rotation based on mouse Y input
        xRotation = Mathf.Clamp(xRotation, -80f, 90f); // Clamp the vertical rotation to prevent flipping
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Apply the vertical rotation to the camera

        playerBody.Rotate(Vector3.up * MouseX * Time.deltaTime * mouseSensitivity); // Rotate the player body based on mouse X input

        Vector3 moveDirection = playerBody.forward * MoveValue.y + playerBody.right * MoveValue.x; // Calculate the movement direction based on input

        characterController.Move(moveDirection * Time.deltaTime * 5f); // Move the character controller in the calculated direction

    }
}
