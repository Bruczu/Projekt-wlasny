using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovementController : MonoBehaviour
{
    public static DropController dropController;
    public int powerUpNumber;
    public float speed;
    //healthUp=1
    //Shield=2
    //DMGBoost=3
    //PiercingBullets=4


    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
        if (transform.position.y <= -6f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            if (powerUpNumber == 1)
            {
                dropController.HealthUp();
                Destroy(gameObject);
            }
            if (powerUpNumber == 2)
            {
                dropController.ShieldActive();
                Destroy(gameObject);
            }
            if (powerUpNumber == 3)
            {
                dropController.DMGBoost();
                Destroy(gameObject);
            }
            if (powerUpNumber == 4)
            {
                dropController.PiercingBullets();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
