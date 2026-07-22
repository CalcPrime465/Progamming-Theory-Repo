using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float initialSpawnRate = 1.5f;
    private float maxSpawnRate = 0.25f;
    private float spawnRateIncrease = 1.01f;
    private float spawnRangeX = 12;
    private float spawnPosY = 8;
    private float spawnPosZ = -4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine(initialSpawnRate));
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    IEnumerator EnemySpawnRoutine(float spawnRate)
    {
        yield return new WaitForSeconds(spawnRate);
        if (spawnRate > maxSpawnRate)
        {
            spawnRate /= spawnRateIncrease;
        }
        SpawnEnemy();
        StartCoroutine(EnemySpawnRoutine(spawnRate));
    }
}
