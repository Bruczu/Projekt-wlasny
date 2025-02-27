using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleMovement : MonoBehaviour
{
    public bool isMovingUp;
    public float bossIdleSpeed;
    public Transform obstacleUp;
    public Transform obstacleDown;

    public static PlayerController playerController;
    public static DropController dropController;
    public static BossSpawner bossSpawner;
    public static EndGameController endGameController;

    void Update()
    {
        UpAndDown();
    }
    public void UpAndDown()
    {
        if (isMovingUp == true)
        {
            transform.Translate(bossIdleSpeed * Time.deltaTime * Vector2.up);
            if (transform.position.y > obstacleUp.position.y)
            {
                isMovingUp = false;
            }
        }
        else
        {
            transform.Translate(bossIdleSpeed * Time.deltaTime * Vector2.down);
            if (transform.position.y < obstacleDown.position.y)
            {
                isMovingUp = true;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (dropController.DMGBoostIsActive == true)
            {
                bossSpawner.bossHP -= 2;
                BossState();
            }
            else
            {
                bossSpawner.bossHP--;
                BossState();
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.HittedByBullet();
            bossSpawner.bossHP--;
            BossState();
        }
    }
    void BossState()
    {
        if (bossSpawner.bossHP <= 0)
        {
            endGameController.playerWon = true;
            Destroy(gameObject);
        }
    }

}
