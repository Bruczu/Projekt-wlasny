using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletSpeed;
    public Rigidbody2D rb;

    public float destroyValue = 9f;

    void Update()
    {
        transform.Translate(Vector2.right * BulletSpeed * Time.deltaTime);
        DestroyAfterLeftScreen();
    }
    void DestroyAfterLeftScreen()
    {
        if (transform.position.x > destroyValue)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
