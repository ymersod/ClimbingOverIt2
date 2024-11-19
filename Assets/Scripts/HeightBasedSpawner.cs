using UnityEngine;

public class HeightBasedSpawner : MonoBehaviour
{
    public GameObject meshPrefab;
    public float spawnHeight = 10f;
    public float heightTolerance = 0.5f;
    private GameObject spawnedMesh;
    public float distanceFromPlayerToMesh = 5f;

    void Update()
    {
        float playerHeight = Camera.main.transform.position.y;

        // Spawn the mesh if it hasn't been spawned and the player is close to the spawn height
        if (spawnedMesh == null && Mathf.Abs(playerHeight - spawnHeight) <= heightTolerance)
        {
            SpawnMesh();
        }
        // Despawn the mesh if the player is below the spawn height minus the tolerance
        else if (spawnedMesh != null && playerHeight < spawnHeight - heightTolerance)
        {
            DespawnMesh();
        }

        // Make the mesh follow the player as they move upwards
        if (spawnedMesh != null)
        {
            FollowPlayer();
        }
    }

    void SpawnMesh()
    {
        Vector3 spawnPosition = new Vector3(0, spawnHeight - distanceFromPlayerToMesh, 0);
        spawnedMesh = Instantiate(meshPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Mesh spawned at height: " + spawnHeight);
    }

    void DespawnMesh()
    {
        if (spawnedMesh != null)
        {
            Destroy(spawnedMesh);
            Debug.Log("Mesh despawned because player is below spawn height.");
        }
    }

    // Makes the spawned mesh follow the player
    void FollowPlayer()
    {
        Vector3 playerPosition = Camera.main.transform.position;
        spawnedMesh.transform.position = new Vector3(playerPosition.x, playerPosition.y - distanceFromPlayerToMesh, playerPosition.z);
    }
}
