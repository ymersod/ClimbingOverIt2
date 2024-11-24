using UnityEngine;

public class PhysicsCorrespondant : MonoBehaviour
{
    [SerializeField] GameObject correspondingPhysicsObject;

    void OnEnable()
    {
        correspondingPhysicsObject.SetActive(true);
    }
    void OnDisable()
    {
        correspondingPhysicsObject.SetActive(false);
    }
}
