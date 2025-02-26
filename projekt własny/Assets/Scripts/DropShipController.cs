using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShipController : MonoBehaviour
{
    public static PlayerController playerController;
    public int shipHP = 2;
    public float shipSpeed = 1;

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
            shipHP--;
            ShipState();
        }
    }
    void ShipState()
    {
        if (shipHP >= 0)
        {
            //Instantiate(dropPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
