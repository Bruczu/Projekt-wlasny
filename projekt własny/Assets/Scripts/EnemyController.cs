using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, fireRate, switchHeight;
    public int enemyHP;
    public static PlayerController playerController;
    public Transform enemyGunEnd;
    public GameObject bulletPrefab;
    private float timeSinceLastShot = 0f;

    public int movePhase;

    void Start()
    {
        
    }


    void Update()
    {
        if (movePhase == 1)
        {
                transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        }
        if (movePhase == 3)
        {
                transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
        }

        if (transform.position.y >= switchHeight)
        {
            StartCoroutine(GoDown()); 
        }        

        if (transform.position.y <= -switchHeight)
        {
            StartCoroutine(GoUp());
        }

        if (transform.position.x < 7f)
        {
            Shoot();
        }

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator GoUp()
    {
        if (movePhase == 1)
        {
            movePhase = 2;
        }
        if (movePhase == 2)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.5f);
            transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.005f);
            movePhase = 3;
        }
    }

    IEnumerator GoDown()
    {
        if (movePhase == 3)
        {
            movePhase = 4;
        }
        if (movePhase == 4)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime , Space.World);
            yield return new WaitForSeconds(0.5f);
            transform.Translate(Vector2.down * speed * Time.deltaTime , Space.World);
            yield return new WaitForSeconds(0.005f);
            movePhase = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            playerController.points = playerController.points + 100;
            //GameManager.enemySpawner.enemy_destroyed();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
           //Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            //GameManager.playerController.HittedByBullet();
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= fireRate)
        {
            Instantiate(bulletPrefab, enemyGunEnd.position, Quaternion.Euler(0, 180, 0));
            timeSinceLastShot = 0;
        }
    }
}
