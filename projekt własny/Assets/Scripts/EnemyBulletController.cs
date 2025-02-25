using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float BulletSpeed;
    public Rigidbody2D rb;
    public float destroyValue;
    public static PlayerController playerController;

    void Update()
    {
        transform.Translate(Vector2.right * BulletSpeed * Time.deltaTime);
        DestroyAfterLeftScreen();
    }
    void DestroyAfterLeftScreen()
    {
        if (Mathf.Abs(transform.position.x) > destroyValue)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Instantiate(bulletExplosionEffect, transform.position, Quaternion.identity);
            playerController.HittedByBullet();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            //Instantiate(bulletExplosionEffect, transform.position, Quaternion.identity);
            playerController.points = playerController.points + 10;
            Destroy(gameObject);
        }
    }
}
