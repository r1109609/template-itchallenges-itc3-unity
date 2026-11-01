using UnityEngine;

public class SnelheidBoostSpawner : MonoBehaviour
{
    public GameObject snelheidsboostPrefab;

    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 6f;

    public float eersteSpawnWachttijd = 8f;
    public float spawnInterval = 20f;

    private void Start()
    {
        InvokeRepeating(
            nameof(SpawnSnelheidsboost),
            eersteSpawnWachttijd,
            spawnInterval
        );
    }

    private void SpawnSnelheidsboost()
    {
        float willekeurigeX = Random.Range(minX, maxX);

        Vector3 spawnPositie = new Vector3(
            willekeurigeX,
            spawnY,
            0f
        );

        Instantiate(
            snelheidsboostPrefab,
            spawnPositie,
            Quaternion.identity
        );
    }
}
