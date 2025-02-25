using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabR, enemyPrefabL;
    public float spawnRate;
    public float timeSinceLastSpawn;

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public bool fromRight;
    public float spawnPlaceRX, spawnPlaceY, spawnPlaceLX;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            if (fromRight == true)
            {
                SpawnEnemyR();
            }
            if (fromRight == false)
            {
                SpawnEnemyL();
            }
        }
    }
    void SpawnEnemyR()
    {
        Vector2 spawnPositionR = new Vector2(spawnPlaceRX, spawnPlaceY);
        GameObject spawnedEnemy = Instantiate(enemyPrefabR, spawnPositionR, Quaternion.identity, this.transform);
        timeSinceLastSpawn = 0f;
        spawnedEnemies.Add(spawnedEnemy);
    }
    void SpawnEnemyL()
    {
        Vector2 spawnPositionL = new Vector2(spawnPlaceLX, spawnPlaceY);
        GameObject spawnedEnemy = Instantiate(enemyPrefabL, spawnPositionL, Quaternion.identity, this.transform);
        timeSinceLastSpawn = 0f;
        spawnedEnemies.Add(spawnedEnemy);
    }
}
