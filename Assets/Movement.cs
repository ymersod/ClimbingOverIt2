using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float maxSpeed = 2f;
    public Rigidbody rigRb;
    public Transform mainCam;
    public InputActionReference leftHandMove;
    public InputActionReference rightHandMove;

    void FixedUpdate()
    {  
        Vector2 leftInput = leftHandMove.action.ReadValue<Vector2>();
        Vector2 rightInput = rightHandMove.action.ReadValue<Vector2>();
        if(leftInput != Vector2.zero || rightInput != Vector2.zero){
            Move(leftInput, rightInput);
        }
    }

    private void Move(Vector2 leftInput, Vector2 rightInput){

        Vector2 combinedInput = leftInput + rightInput;

        Vector3 cameraForward = mainCam.forward;
        Vector3 cameraRight = mainCam.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movementDirection = (cameraForward * combinedInput.y + cameraRight * combinedInput.x).normalized;

        rigRb.AddForce(movementDirection * speed, ForceMode.VelocityChange);

        if(rigRb.linearVelocity.x > maxSpeed){
            rigRb.linearVelocity = new Vector3(maxSpeed, rigRb.linearVelocity.y, rigRb.linearVelocity.z);
        }
        if(rigRb.linearVelocity.z > maxSpeed){
            rigRb.linearVelocity = new Vector3(rigRb.linearVelocity.x, rigRb.linearVelocity.y, maxSpeed);
        }
    }
}
