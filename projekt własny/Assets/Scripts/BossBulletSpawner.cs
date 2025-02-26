using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin}

    //[Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public float bulletLife = 1f;
    public float speed = 1f;

    //[Header("Spawner Attributes)]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float fireRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z+1f);
        if(timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab)
        {
            spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<BossBulletController>().speed = speed;
            spawnedBullet.GetComponent<BossBulletController>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
