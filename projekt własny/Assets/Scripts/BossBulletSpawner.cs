using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, Straight2 }

    //[Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public float bulletLife = 1f;
    public float speed = 1f;
    public float spinSpeed;

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
        Spin1();
        Spin2();
        Straight1();
        Straight2();
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
    private void Spin1()
    {
        if (((bossController.bossPhase == 1) || (bossController.bossPhase == 3)) && (spawnerType == SpawnerType.Spin))
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + spinSpeed);
            if (timer >= fireRate)
            {
                Shoot();
                timer = 0;
            }
        }
    }

    private void Spin2()
    {
        if ((bossController.bossPhase == 2) && (spawnerType == SpawnerType.Spin))
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z - spinSpeed);
            if (timer >= fireRate)
            {
                Shoot();
                timer = 0;
            }
        }
    }
    private void Straight1()
    {
        if (((bossController.bossPhase == 4) || (bossController.bossPhase == 6)) && (spawnerType == SpawnerType.Straight))
        {
            if (timer >= fireRate)
            {
                Shoot();
                timer = 0;
            }
        }
    }
    private void Straight2()
    {
        if (((bossController.bossPhase == 5) || (bossController.bossPhase == 7)) && (spawnerType == SpawnerType.Straight2))
        {
            if (timer >= fireRate)
            {
                Shoot();
                timer = 0;
            }
        }
    }
}

