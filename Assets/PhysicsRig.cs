using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PhysicsRig : MonoBehaviour
{
    public Transform playerHead;
    // public Transform leftController;
    // public Transform rightController;
    // // public ConfigurableJoint headJoint;
    // public ConfigurableJoint leftHandJoint;
    // public ConfigurableJoint rightHandJoint;
    public SphereCollider headCollider;
    public Transform playerRig;
    public float playerHeight = 1.5f;

    void FixedUpdate()
    {
        // if(playerRig.position.y < playerHeight)
        // {
        //     playerRig.position = new Vector3(playerRig.position.x, playerHeight, playerRig.position.z);
        // }

        // headCollider.transform.position = playerHead.position;

        // rightHandJoint.targetPosition = rightController.localPosition;
        // rightHandJoint.targetRotation = rightController.localRotation;

        // leftHandJoint.targetPosition = leftController.localPosition;
        // leftHandJoint.targetRotation = leftController.localRotation;
    }
}   
