using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject Enemy2PrefabR, Enemy2PrefabL;
    public float spawnRate;

    public float minYAxisSpawnValue, maxYAxisSpawnValue;
    public int XAxisSpawnValue;
    private float timeSinceLastSpawn;

    public List<GameObject> spawnedEnemy2List = new List<GameObject>();

    public bool fromRight;
    public static EndGameController endGameController;

    void Update()
    {
        if (endGameController.gamePhase == 2)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= spawnRate)
            {
                SpawnEnemy2R();
            }
        }

    }

    void SpawnEnemy2R()
    {
        float yPosition = Random.Range(minYAxisSpawnValue, maxYAxisSpawnValue);
        int[] numbers = { -10, 10 };
        int XAxisSpawnValue = numbers[Random.Range(0, numbers.Length)];
        Vector2 spawnPosition = new Vector2(XAxisSpawnValue, yPosition);

        float yPosition2 = Random.Range(minYAxisSpawnValue, maxYAxisSpawnValue);
        int[] numbers2 = { -10, 10 };
        int XAxisSpawnValue2 = numbers2[Random.Range(0, numbers2.Length)];
        Vector2 spawnPosition2 = new Vector2(XAxisSpawnValue2, yPosition2);

        if (XAxisSpawnValue == 10)
        {
            GameObject spawnedEnemy2 = Instantiate(Enemy2PrefabR, spawnPosition, Quaternion.identity, this.transform);
            timeSinceLastSpawn = 0f;
            spawnedEnemy2List.Add(spawnedEnemy2);
        }
        if (XAxisSpawnValue == -10)
        {
            GameObject spawnedEnemy2 = Instantiate(Enemy2PrefabL, spawnPosition, Quaternion.identity, this.transform);
            timeSinceLastSpawn = 0f;
            spawnedEnemy2List.Add(spawnedEnemy2);
        }

        if (XAxisSpawnValue2 == 10)
        {
            GameObject spawnedEnemy2 = Instantiate(Enemy2PrefabR, spawnPosition2, Quaternion.identity, this.transform);
            timeSinceLastSpawn = 0f;
            spawnedEnemy2List.Add(spawnedEnemy2);
        }
        if (XAxisSpawnValue2 == -10)
        {
            GameObject spawnedEnemy2 = Instantiate(Enemy2PrefabL, spawnPosition2, Quaternion.identity, this.transform);
            timeSinceLastSpawn = 0f;
            spawnedEnemy2List.Add(spawnedEnemy2);
        }
    }
}

