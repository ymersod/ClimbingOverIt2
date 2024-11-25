using System.Collections;
using UnityEngine;

public class DisableCol : MonoBehaviour
{
    private MeshCollider col;
    private int handsTouching = 0;
    void OnEnable()
    {
        col = GetComponent<MeshCollider>();
    }

    public void UpHandInputs()
    {
        handsTouching++;
    }

    public void DisableMeeee()
    {
        handsTouching--;
        if(handsTouching == 0)
        {
            col.enabled = false;
            StartCoroutine(ReEnableColliderAfterDelay(2f));
        }
    }

    private IEnumerator ReEnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        col.enabled = true; 
    }
}
