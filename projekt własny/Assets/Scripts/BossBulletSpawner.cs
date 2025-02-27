using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, Straight2}

    //[Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public float bulletLife = 1f;
    public float speed = 1f;
    public float spinSpeed;
    public bool spinDirection;

    //[Header("Spawner Attributes)]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float fireRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    public static BossController bossController;

    void Update()
    {
        timer += Time.deltaTime;
        if (bossController.bossPhase == 0)
        {
            
        }
        if ((bossController.bossPhase == 1 ) && (spawnerType == SpawnerType.Spin))
        {
            if (spinDirection == false)
            {
                transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + spinSpeed);
                if (timer >= fireRate)
                {
                    Shoot();
                    timer = 0;
                }
            }
            if (spinDirection == true)
            {
                transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z - spinSpeed);
                if (timer >= fireRate)
                {
                    Shoot();
                    timer = 0;
                }
            }
        }
        if (bossController.bossPhase == 2 && (spawnerType == SpawnerType.Straight))
        {
            if (timer >= fireRate)
            {
                Shoot();
                timer = 0;
            }
        }
        if (bossController.bossPhase == 3 && (spawnerType == SpawnerType.Straight2))
        {
            if (timer >= fireRate)
            {
                Shoot();
                timer = 0;
            }
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
