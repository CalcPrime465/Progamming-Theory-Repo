using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine(2));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector3 spawn = new Vector3(Random.Range(-12, 12), 8, -4);
        Instantiate(enemyPrefab, spawn, enemyPrefab.transform.rotation);
    }

    IEnumerator EnemySpawnRoutine(float spawnRate)
    {
        yield return new WaitForSeconds(spawnRate);
        spawnRate /= 1.01f;
        SpawnEnemy();
        StartCoroutine(EnemySpawnRoutine(spawnRate));
    }
}
