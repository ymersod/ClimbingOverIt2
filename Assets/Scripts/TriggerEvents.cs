using UnityEngine;

public class TriggerEvents : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var physicsHand = other.gameObject.GetComponent<PhysicsHand>();
            if (physicsHand != null)
            {
                physicsHand._isColliding = true;
            }
            else
            {
                var physicsController = other.gameObject.GetComponent<PhysicsController>();
                if (physicsController != null)
                {
                    physicsController._isColliding = true;
                }
                else
                {
                    Debug.LogWarning($"Neither PhysicsHand nor PhysicsController found on {other.gameObject.name}");
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        var physicsHand = other.gameObject.GetComponent<PhysicsHand>();
            if (physicsHand != null)
            {
                physicsHand._isColliding = false;
            }
            else
            {
                var physicsController = other.gameObject.GetComponent<PhysicsController>();
                if (physicsController != null)
                {
                    physicsController._isColliding = false;
                }
                else
                {
                    Debug.LogWarning($"Neither PhysicsHand nor PhysicsController found on {other.gameObject.name}");
                }
            }
    }
}
