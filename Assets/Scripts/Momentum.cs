using UnityEngine;

public class VRHandMomentum : MonoBehaviour
{
    public Rigidbody bodyRb;  // The Rigidbody attached to the main body (the object being affected by momentum)
    public Transform handTarget;  // The target transform representing the hand/controller (left or right hand)
    public float clamberDrag = 1f;  // Base drag value to control momentum decay

    private Vector3 prevPosition;  // Previous position of the hand to calculate velocity
    private Vector3 handVel;  // Current velocity of the hand
    private float drag;  // The calculated drag factor based on hand velocity

    void Start()
    {
        prevPosition = handTarget.localPosition;  // Initialize previous position of the hand
    }

    void FixedUpdate()
    {
        
    }

    void ApplyMomentum()
    {
        // Calculate the velocity of the hand (controller)
        handVel = (handTarget.localPosition - prevPosition) / Time.fixedDeltaTime;

        // Calculate the drag based on the hand's velocity magnitude, ensuring reasonable limits
        drag = 1 / handVel.magnitude + 0.01f;  // Inverse of speed, + small constant to avoid division by zero
        drag = Mathf.Clamp(drag, 0.3f, 1f);  // Clamp the drag to stay within a reasonable range

        // Transfer momentum from the hand's velocity to the main body
        Vector3 momentumTransfer = handVel * bodyRb.mass;  // Scale the hand's velocity by the body's mass
        bodyRb.AddForce(momentumTransfer * clamberDrag * drag, ForceMode.VelocityChange);  // Apply force to the body (momentum transfer)

        // Apply additional drag to slow down the body's momentum (simulating resistance)
        bodyRb.AddForce(-bodyRb.linearVelocity * clamberDrag * drag, ForceMode.VelocityChange);  // Apply drag to slow down

        // Update the previous hand position for the next frame
        prevPosition = handTarget.localPosition;
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Map"))
        {
            ApplyMomentum(); 
        }
    }
}
