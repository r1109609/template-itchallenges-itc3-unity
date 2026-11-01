using UnityEngine;

public class MuntenSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 6f;

    public float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 1f, spawnInterval);
    }

    private void SpawnCoin()
    {
        float randomX = Random.Range(minX, maxX);

        Vector3 spawnPosition = new Vector3(
            randomX,
            spawnY,
            0f
        );

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
