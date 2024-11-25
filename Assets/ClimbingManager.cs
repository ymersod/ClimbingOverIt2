using UnityEngine;

public class ClimbingManager : MonoBehaviour
{
    [SerializeField] GameObject RightHandThingy;
    [SerializeField] GameObject LeftHandThingy;
    [SerializeField] GameObject RightHandClimbing;
    [SerializeField] GameObject LeftHandClimbing;
    [SerializeField] Transform headPos;
    [SerializeField] Transform xrRig;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] CharacterController characterController;
    private int nrActive = 0;
    public void ActiveClimbing()
    {
        playerRb.isKinematic = true;
        playerRb.useGravity = false;

        RightHandClimbing.SetActive(true);
        LeftHandClimbing.SetActive(true);
        RightHandThingy.SetActive(false);
        LeftHandThingy.SetActive(false);
        LeftHandThingy.GetComponent<PhysicsController>()._isColliding = false;
        RightHandThingy.GetComponent<PhysicsController>()._isColliding = false;
        nrActive++;
    }

    public void DeactiveClimbing()
    {
        nrActive--;
        if(nrActive == 0) {
            playerRb.isKinematic = false;
            playerRb.useGravity = true;

            RightHandClimbing.SetActive(false);
            LeftHandClimbing.SetActive(false);
            RightHandThingy.SetActive(true);
            LeftHandThingy.SetActive(true);
            RightHandThingy.GetComponent<PhysicsController>().SetTimer();
            LeftHandThingy.GetComponent<PhysicsController>().SetTimer();
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
        }
    }

    void LateUpdate()
    {
        if(nrActive > 0)
        {
            playerRb.position = characterController.transform.position;
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
        }
    }
}
