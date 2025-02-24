using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float minXValue;
    public float maxXValue;
    public float minYValue;
    public float maxYValue;

    public GameObject playerBulletPrefab;
    public Transform gunEndPosition;

    public float gunFireRate;
    public float timeSinceLastShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKey(KeyCode.Space))
        {
            GunShoot();
        }
    }

    void PlayerMovement()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        float vertivalInputValue = Input.GetAxis("Vertical");
        Vector2 movementVector = new Vector2 (horizontalInputValue, vertivalInputValue) * playerSpeed * Time.deltaTime;
        transform.Translate(movementVector);

        if (transform.position.x > maxXValue)
        {
            transform.position = new Vector2(maxXValue, transform.position.y);
        }

        if (transform.position.x < minXValue)
        {
            transform.position = new Vector2(minXValue, transform.position.y);
        }

        if (transform.position.y > maxYValue)
        {
            transform.position = new Vector2(transform.position.x, maxYValue);
        }

        if (transform.position.y < minYValue)
        {
            transform.position = new Vector2(transform.position.x, minYValue);
        }
    }
    void GunShoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= gunFireRate)
        {
            Instantiate(playerBulletPrefab, gunEndPosition.position, Quaternion.identity);
            //audioSource.PlayOneShot(audioClip);
            timeSinceLastShot = 0f;
        }
    }
}
