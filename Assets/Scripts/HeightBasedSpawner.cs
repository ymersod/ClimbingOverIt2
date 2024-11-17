using UnityEngine;

public class HeightBasedSpawner : MonoBehaviour
{
    public GameObject meshPrefab;
    public float spawnHeight = 10f;
    public float heightTolerance = 0.5f;
    private GameObject spawnedMesh;

    void Update()
    {
        float playerHeight = Camera.main.transform.position.y;

        if (spawnedMesh == null && Mathf.Abs(playerHeight - spawnHeight) <= heightTolerance)
        {
            SpawnMesh();
        }
        else if (spawnedMesh != null && playerHeight < spawnHeight - heightTolerance)
        {
            DespawnMesh();
        }
    }

    void SpawnMesh()
    {
        if (meshPrefab == null)
        {
            Debug.LogError("Mesh Prefab is not assigned in the inspector!");
            return;
        }

        Vector3 spawnPosition = new Vector3(0, spawnHeight, 0);
        spawnedMesh = Instantiate(meshPrefab, spawnPosition, Quaternion.identity);

        Debug.Log("Mesh spawned at height: " + spawnHeight);
    }

    void DespawnMesh()
    {
        // Destroy the spawned mesh
        if (spawnedMesh != null)
        {
            Destroy(spawnedMesh);
            Debug.Log("Mesh despawned because player is below spawn height.");
        }
    }
}
