using UnityEngine;

public class RigidBodyFollow : MonoBehaviour
{
    public Transform trackedPoseTarget;
    public Rigidbody rb;
    public float positionLerpSpeed = 10f;
    public float rotationLerpSpeed = 10f;

    void FixedUpdate()
    {
        Vector3 targetPosition = trackedPoseTarget.position;
        Quaternion targetRotation = trackedPoseTarget.rotation;

        rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, Time.fixedDeltaTime * positionLerpSpeed));
        rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, Time.fixedDeltaTime * rotationLerpSpeed));
    }
}
