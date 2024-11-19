using UnityEngine;

public class col : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter " + other.gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PhysicsHand>()._isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit " + other.gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PhysicsHand>()._isColliding = false;
        }
    }
}
