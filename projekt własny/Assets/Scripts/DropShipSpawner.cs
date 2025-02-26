using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShipSpawner : MonoBehaviour
{
    public GameObject dropShipPrefabR, dropShipPrefabL;
    public float spawnRate;

    public float minYAxisSpawnValue, maxYAxisSpawnValue;
    public int XAxisSpawnValue;
    private float timeSinceLastSpawn = 0f;

    public List<GameObject> spawnedDropShips = new List<GameObject>();

    public bool fromRight;


    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
             SpawnDropShip();
        }
    }

    void SpawnDropShip()
    {
        float yPosition = Random.Range(minYAxisSpawnValue, maxYAxisSpawnValue);
        int[] numbers = { -10, 10 };
        int XAxisSpawnValue = numbers[Random.Range(0, numbers.Length)];

        Vector2 spawnPosition = new Vector2(XAxisSpawnValue, yPosition);
        if (XAxisSpawnValue == -10)
        {
            GameObject spawnedEnemy = Instantiate(dropShipPrefabL, spawnPosition, Quaternion.identity, this.transform);
            spawnedDropShips.Add(spawnedEnemy);
        }
        if (XAxisSpawnValue == 10)
        {
            GameObject spawnedEnemy = Instantiate(dropShipPrefabR, spawnPosition, Quaternion.identity, this.transform);
            spawnedDropShips.Add(spawnedEnemy);
        }

        timeSinceLastSpawn = 0f;
    }
}
