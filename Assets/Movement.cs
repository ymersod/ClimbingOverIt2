using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rigRb;
    public Transform mainCam;
    public InputActionReference leftHandMove;
    public InputActionReference rightHandMove;

    void FixedUpdate()
    {  
        // Get input values for left and right hand movement
        Vector2 leftInput = leftHandMove.action.ReadValue<Vector2>();
        Vector2 rightInput = rightHandMove.action.ReadValue<Vector2>();

        // Combine inputs (or pick one if only one should control movement)
        Vector2 combinedInput = leftInput + rightInput;

        // Use the camera's forward and right directions for movement
        Vector3 cameraForward = mainCam.forward;
        Vector3 cameraRight = mainCam.right;

        // Zero out y components to keep movement on the horizontal plane
        cameraForward.y = 0;
        cameraRight.y = 0;
        
        // Normalize directions after modifying them
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on camera orientation and input
        Vector3 movementDirection = (cameraForward * combinedInput.y + cameraRight * combinedInput.x).normalized;

        // Apply movement to the Rigidbody in the calculated direction
        rigRb.MovePosition(rigRb.position + movementDirection * speed * Time.fixedDeltaTime);
    }
}
