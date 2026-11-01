using UnityEngine;

public class SchildSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;

    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 6f;

    public float spawnInterval = 15f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnShield), 5f, spawnInterval);
    }

    private void SpawnShield()
    {
        float randomX = Random.Range(minX, maxX);

        Vector3 spawnPosition = new Vector3(
            randomX,
            spawnY,
            0f
        );

        Instantiate(
            shieldPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}
