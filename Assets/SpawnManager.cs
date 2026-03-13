using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject enemyPrefab;

    public float spawnX = 9f;
    public float minY = -4f;
    public float maxY = 4f;

    public float meteorSpawnRate = 2f;
    public float enemySpawnRate = 5f;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, meteorSpawnRate);
        InvokeRepeating("SpawnEnemy", 2f, enemySpawnRate);
    }

    void SpawnMeteor()
    {
        float y = Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(meteorPrefab, pos, Quaternion.identity);
    }

    void SpawnEnemy()
    {
        float y = Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}