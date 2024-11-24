using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftController;
    [SerializeField] GameObject rightController;
    void Start()
    {
        leftHand.SetActive(false);
        rightHand.SetActive(false);
        leftController.SetActive(false);
        rightController.SetActive(false);
    }
}
