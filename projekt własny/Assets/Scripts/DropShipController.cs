using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShipController : MonoBehaviour
{
    public static PlayerController playerController;
    public static DropController dropController;
    public int shipHP;
    public float shipSpeed;
    public bool goingRight;
    [SerializeField] private SpriteRenderer dropShipSprite;
    [SerializeField] private Sprite turnedRight;
    [SerializeField] private Sprite turnedLeft;

    public GameObject HealthUpPrefab, ShieldPrefab, DMGBoostPrefab, PiercingBulletsPrefab;

    void Start()
    {
        int[] speedOptions = { 1, 2, 3, 4 };
        shipSpeed = speedOptions[Random.Range(0, speedOptions.Length)];

        if (goingRight == true)
        {
            dropShipSprite.sprite = turnedRight;
        }
        else
        {
            dropShipSprite.sprite = turnedLeft;
        }
    }
    void Update()
    {
        if (goingRight == true)
        {
            transform.Translate(shipSpeed * Time.deltaTime * Vector2.right);
        }
        else
        {
            transform.Translate(shipSpeed * Time.deltaTime * Vector2.left);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Instantiate(bulletExplosionEffect, transform.position, Quaternion.identity);
            playerController.HittedByBullet();
            shipHP --;
            ShipState();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Instantiate(bulletExplosionEffect, transform.position, Quaternion.identity);
            //playerController.points += 10;
            if (dropController.DMGBoostIsActive == true)
            {
                shipHP-= 2;
                ShipState();
            }
            else
            {
                shipHP--;
                ShipState();
            }
        }
    }
    void ShipState()
    {
        if (shipHP <= 0)
        {
            int[] dropOption = { 1, 2, 3, 4};
            int drop = dropOption[Random.Range(0, dropOption.Length)];
            if (drop == 1)
            {
                Instantiate(HealthUpPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (drop == 2)
            {
                Instantiate(ShieldPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (drop == 3)
            {
                Instantiate(DMGBoostPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (drop == 4)
            {
                Instantiate(PiercingBulletsPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
