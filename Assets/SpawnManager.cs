using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    public GameObject meteorPrefabGrande;
    public GameObject meteorPrefabMedio;
    public GameObject meteorPrefabPequeno;
    public GameObject meteorPrefabMini;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;

    public float spawnX = 9f;
    public float minY = -4f;
    public float maxY = 4f;

    public float meteorSpawnRate = 0.5f;
    public float enemySpawnRate = 2.5f;

    Action[] funcoes;
    Action[] enemies;

    void Start()
    {
        funcoes = new Action[] { SpawnMeteorGrande, SpawnMeteorMedio, SpawnMeteorPequeno, SpawnMeteorMini};
        enemies = new Action[] { SpawnEnemy, SpawnEnemy2 };
        InvokeRepeating("SpawnEnemyRandom", 1f, enemySpawnRate);
        InvokeRepeating("SpawnMeteorRandom", 0.5f, meteorSpawnRate);
    }

    void SpawnMeteorGrande()
    {
        float y = UnityEngine.Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(meteorPrefabGrande, pos, Quaternion.identity);
    }
    void SpawnMeteorMedio()
    {
        float y = UnityEngine.Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(meteorPrefabMedio, pos, Quaternion.identity);
    }
    void SpawnMeteorPequeno()
    {
        float y = UnityEngine.Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(meteorPrefabPequeno, pos, Quaternion.identity);
    }
    void SpawnMeteorMini()
    {
        float y = UnityEngine.Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(meteorPrefabMini, pos, Quaternion.identity);
    }

    void SpawnEnemy()
    {
        float y = UnityEngine.Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
    void SpawnEnemy2()
    {
        float y = UnityEngine.Random.Range(minY, maxY);
        Vector2 pos = new Vector2(spawnX, y);

        Instantiate(enemyPrefab2, pos, Quaternion.identity);
    }

    void SpawnEnemyRandom()
    {
        int index = UnityEngine.Random.Range(0, enemies.Length);
        enemies[index].Invoke();
    }

    void SpawnMeteorRandom()
    {
        int index = UnityEngine.Random.Range(0, funcoes.Length);
        funcoes[index].Invoke();
    }
}