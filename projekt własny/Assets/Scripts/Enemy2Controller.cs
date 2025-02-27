using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public bool movingRight;
    public float speed, timeSinceLastShot, fireRate;
    public int enemyHP;
    public static DropController dropController;
    public static PlayerController playerController;
    public GameObject bulletPrefab;
    public Transform enemyGunEnd;
    void Start()
    {
        int[] speedOptions = { 2, 3, 4, 5, 6 };
        speed = speedOptions[Random.Range(0, speedOptions.Length)];
    }
    void Update()
    {
        if (movingRight == true)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.right, Space.World);
        }
        if (movingRight == false)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.left, Space.World);
        }
        /*if (transform.position.x < 7f || transform.position.x > -7f)
        {
            Shoot();
        }*/

        if (Mathf.Abs(transform.position.x) > 12f)
        {
            Destroy(gameObject);
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
            playerController.HittedByBullet();
            enemyHP--;
            ShipState();
        }
    }
    /*void Shoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= fireRate)
        {
            if (movingRight == false)
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
    }*/
    void ShipState()
    {
        if (enemyHP <= 0)
        {
            playerController.points += 100;
            Destroy(gameObject);
        }
    }
}
