using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    InputSystem_Actions inputActions;

    public Transform playerBody;
    public Camera playerCamera;
    public float mouseSensitivity = 100f;
    public Transform groundCheck;
    public CharacterController characterController; 
    float xRotation = 0f;
    bool isGrounded = false;
    public LayerMask groundMask;
    public float gravity = -9.81f;
    Vector3 downVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        inputActions = new InputSystem_Actions(); 
        inputActions.Player.Enable();
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

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, groundMask);
        

        if (isGrounded && downVelocity.y < 0)
        {
            downVelocity.y = -.02f; // Reset the downward velocity when grounded
        }
        downVelocity.y += gravity * Time.deltaTime*Time.deltaTime; 
        characterController.Move(downVelocity);
    }
}
