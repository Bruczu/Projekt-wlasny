using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    public float timeSinceLastSpawn;

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(8, 6);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, this.transform);
        timeSinceLastSpawn = 0f;
        spawnedEnemies.Add(spawnedEnemy);
    }
}
