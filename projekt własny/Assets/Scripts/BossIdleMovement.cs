using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleMovement : MonoBehaviour
{
    public bool isMovingUp;
    public float bossIdleSpeed;
    public Transform obstacleUp;
    public Transform obstacleDown;
    void Start()
    {
        
    }

    
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
}
