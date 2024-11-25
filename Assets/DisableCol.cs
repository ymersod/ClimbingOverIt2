using UnityEngine;

public class DisableCol : MonoBehaviour
{
    private MeshCollider col;
    void Start()
    {
        col = GetComponent<MeshCollider>();
    }
    public void DisableMeeee()
    {
        col.enabled = false;
    }
}
