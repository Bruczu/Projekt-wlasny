using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletSpeed;
    public Rigidbody2D rb;

    public float destroyValue;

    public static DropController dropController;

    void Update()
    {
        transform.Translate(BulletSpeed * Time.deltaTime * Vector2.right);
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
        if (dropController.PiercingBulletsIsActive == true)
        {

        }
        if (collision.gameObject.CompareTag("BossBullet"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
