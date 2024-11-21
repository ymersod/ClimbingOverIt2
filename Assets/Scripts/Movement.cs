using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Hands;

public class Movement : MonoBehaviour
{
    public float speed = .1f;
    public float maxSpeed = 5f;
    public Rigidbody rigRb;
    public Transform mainCam;
    public InputActionReference leftHandMove;
    public InputActionReference rightHandMove;
    public XRHandTrackingEvents leftHandEvents;
    public bool grappling = false;

    void FixedUpdate()
    {  
        Vector2 leftInput = leftHandMove.action.ReadValue<Vector2>();
        Vector2 rightInput = rightHandMove.action.ReadValue<Vector2>();
        if (grappling)
        {
            // physics stuff here on body could be cool? maybe set hand grappling as primary rigidbody
        }
        else if(leftInput != Vector2.zero || rightInput != Vector2.zero){
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

        Vector3 horizontalVelocity = new Vector3(rigRb.linearVelocity.x, 0, rigRb.linearVelocity.z); // Horizontal speed only
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed; // Limit to max speed
            rigRb.linearVelocity = new Vector3(horizontalVelocity.x, rigRb.linearVelocity.y, horizontalVelocity.z);
        }
    }

    public void MomentumAfterGrap()
    {
        // rigRb.AddForce(rigRb.linearVelocity * 10f, ForceMode.VelocityChange);

        // Vector3 handVel = (handtarget.localPosition - prevPosition) / Time.fixedDeltaTime;
        // float drag = 1/handVel.magnitude + 0.01f;
        // drag = drag >= 1 ? 1 : drag;
        // drag = drag <= 0.3f ? 0.3f : drag;
        // rigRb.AddForce(-rigRb.linearVelocity * clamberDrag * drag);
    }

    public void Grappling(bool grappling)
    {
        this.grappling = grappling;
    }
}
