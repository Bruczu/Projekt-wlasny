using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, fireRate, switchHeightUp, switchHeightDown;
    public int enemyHP;
    public static PlayerController playerController;
    public static DropController dropController;
    public Transform enemyGunEnd;
    public GameObject bulletPrefab;
    private float timeSinceLastShot = 0f;
    public bool goingFromRight;

    public int movePhase;


    void Update()
    {
        if (movePhase == 1)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.down, Space.World);
        }
        if (movePhase == 3)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up, Space.World);
        }

        if (transform.position.y >= switchHeightUp)
        {
            StartCoroutine(GoDown());
        }

        if (transform.position.y <= switchHeightDown)
        {
            StartCoroutine(GoUp());
        }

        if (transform.position.x < 7f || transform.position.x > -7f)
        {
            Shoot();
        }

        if (Mathf.Abs(transform.position.x) > 12f)
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
            if (goingFromRight == true)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.left, Space.World);
                yield return new WaitForSeconds(0.2f);
                movePhase = 3;
            }
            else
            {
                transform.Translate(speed * Time.deltaTime * Vector2.right, Space.World);
                yield return new WaitForSeconds(0.2f);
                movePhase = 3;
            }

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
            if (goingFromRight == true)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.left, Space.World);
                yield return new WaitForSeconds(0.2f);
                movePhase = 1;
            }
            else
            {
                transform.Translate(speed * Time.deltaTime * Vector2.right, Space.World);
                yield return new WaitForSeconds(0.2f);
                movePhase = 1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (dropController.DMGBoostIsActive == true)
            {
                enemyHP -= 2;
                ShipState();
            }
            else
            {
                enemyHP--;
                ShipState();
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            playerController.HittedByBullet();
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= fireRate)
        {
            if (goingFromRight == true)
            {
                Instantiate(bulletPrefab, enemyGunEnd.position, Quaternion.Euler(0, 180, 0));
                timeSinceLastShot = 0;
            }
            else
            {
                Instantiate(bulletPrefab, enemyGunEnd.position, Quaternion.identity);
                timeSinceLastShot = 0;
            }
        }
    }
    void ShipState()
    {
        if (enemyHP <= 0)
        {
            playerController.points += 100;
            Destroy(gameObject);
            //Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            //GameManager.enemySpawner.enemy_destroyed();
        }
    }
}
