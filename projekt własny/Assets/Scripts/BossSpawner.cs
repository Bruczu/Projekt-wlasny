using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public static EndGameController endGameController;
    public GameObject bossPrefab;
    public float spawnPlaceX, spawnPlaceY;
    public bool bossSpawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((endGameController.gamePhase == 3) && (bossSpawned == false))
        {
            SpawnBoss();
        }
    }
    void SpawnBoss()
    {
        Vector2 spawnPosition = new Vector2(spawnPlaceX, spawnPlaceY);
        GameObject spawnedEnemy = Instantiate(bossPrefab, spawnPosition, Quaternion.identity, this.transform);
        bossSpawned = true;
    }

}
