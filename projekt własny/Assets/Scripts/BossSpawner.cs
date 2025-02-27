using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public static EndGameController endGameController;
    public GameObject bossPrefab;
    public float spawnPlaceX, spawnPlaceY;
    public bool bossSpawned;
    public int bossHP;
    void Start()
    {
        UIController.bossSpawner = this;
        BossIdleMovement.bossSpawner = this;
    }
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
        Instantiate(bossPrefab, spawnPosition, Quaternion.identity, this.transform);
        bossSpawned = true;
    }

}
