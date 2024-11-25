using UnityEngine;
using System.Collections;

public class ColDebug : MonoBehaviour
{

    void Start()
    {
        GetComponent<Collider>().enabled = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
