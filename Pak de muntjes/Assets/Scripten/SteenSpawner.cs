using UnityEngine;

public class SteenSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public float minX = -7f;
    public float maxX = 7f;

    public float spawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    public float intervalDecreasePerSecond = 0.02f;

    public int rocksPerWave = 2;
    public int maxRocksPerWave = 5;

    private float elapsedTime = 0f;
    private float spawnTimer = 0f;

    private void Start()
    {
        int moeilijkheid = PlayerPrefs.GetInt("Moeilijkheid", 0);

        if (moeilijkheid == 0)
        {
            // Makkelijk
            spawnInterval = 3f;
            minSpawnInterval = 1.2f;
            intervalDecreasePerSecond = 0.01f;
            rocksPerWave = 1;
            maxRocksPerWave = 3;
        }
        else
        {
            // Moeilijk
            spawnInterval = 2f;
            minSpawnInterval = 0.5f;
            intervalDecreasePerSecond = 0.02f;
            rocksPerWave = 2;
            maxRocksPerWave = 5;
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        float currentInterval = Mathf.Max(
            minSpawnInterval,
            spawnInterval - elapsedTime * intervalDecreasePerSecond
        );

        if (spawnTimer >= currentInterval)
        {
            SpawnWave();
            spawnTimer = 0f;
        }
    }

    private void SpawnWave()
    {
        int amount = Mathf.Min(
            maxRocksPerWave,
            rocksPerWave + Mathf.FloorToInt(elapsedTime / 15f)
        );

        for (int i = 0; i < amount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, 6f + i * 0.5f, 0f);

            GameObject rock = Instantiate(
                rockPrefab,
                spawnPosition,
                Quaternion.identity
            );

            Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = Mathf.Min(
                    5f,
                    1f + elapsedTime * 0.05f
                );
            }
        }
    }
}
