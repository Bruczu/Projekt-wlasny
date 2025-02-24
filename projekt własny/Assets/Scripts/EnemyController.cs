using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, fireRate, switchHeight, directionSwitchLimit;
    //private float timeSinceLastAction;
    public float timeSinceLastSwitch;
    public int enemyHP;
    public static PlayerController playerController;
    public Transform enemyGunEnd;
    //public GameObject bulletPrefab;

    public int movePhase;

    void Start()
    {
        
    }


    void Update()
    {
        if (movePhase == 1)
        {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (movePhase == 3)
        {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (transform.position.y >= switchHeight)
        {
                StartCoroutine(GoDown()); 
        }        
        
        /*if (Mathf.Abs(transform.position.y) >= switchHeight)
        {
                StartCoroutine(GoOtherWay()); 
        }*/

        if (transform.position.y <= -switchHeight)
        {
            StartCoroutine(GoUp());
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
            transform.Translate(Vector2.left * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(1f);
            transform.Translate(Vector2.up * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.2f);
            movePhase = 3;
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
            transform.Translate(Vector2.left * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(1f);
            transform.Translate(Vector2.down * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.2f);
            movePhase = 1;
        }
    }
}
