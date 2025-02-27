using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float playerArrivalSpeed;
    public float minXValue;
    public float maxXValue;
    public float minYValue;
    public float maxYValue;
    public int points;
    //public int pointsNeeded;

    public int playerHP;
    public int maxPlayerHP;

    public GameObject playerBulletPrefab;
    public Transform gunEndPositionR;
    public Transform gunEndPositionL;
    //
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Sprite turnedRight;
    [SerializeField] private Sprite turnedLeft;
    public bool lastShotSide = false;
    //

    public float gunFireRate;
    public float timeSinceLastShot;

    public static DropController dropController;

    public bool playerCanMove;
    public bool playerArrived;
    public float arrivalDuration;
    public float arrivalDurationMax;

    void Start()
    {
        EnemyController.playerController = this;
        DropShipController.playerController = this;
        DropController.playerController = this;
        EnemyBulletController.playerController = this;
        EndGameController.playerController = this;
        Enemy2Controller.playerController = this;
        BossIdleMovement.playerController = this;
        BossBulletController.playerController = this;
        playerCanMove = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCanMove == false)
        {
            PlayerArrival();
        }
        if (playerCanMove == true)
        {
            PlayerMovement();
        }
        if (Input.GetKey(KeyCode.X))
        {
            GunShootR();
            lastShotSide = false;
        }
        else
        {
            if (Input.GetKey(KeyCode.Z))
            {
                GunShootL();
                lastShotSide = true;
            }
        }

        if (lastShotSide == false)
        {
            playerSprite.sprite = turnedRight;
        }
        else
        {
            playerSprite.sprite = turnedLeft;
        }
    }

    void PlayerMovement()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        float vertivalInputValue = Input.GetAxis("Vertical");
        //
        Vector2 movementVector =  playerSpeed * Time.deltaTime * new Vector2(horizontalInputValue, vertivalInputValue);
        //
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
    void GunShootR()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= gunFireRate)
        {
            Instantiate(playerBulletPrefab, gunEndPositionR.position, Quaternion.identity);
            //audioSource.PlayOneShot(audioClip);
            timeSinceLastShot = 0f;
        }
    }
    void GunShootL()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= gunFireRate)
        {
            Instantiate(playerBulletPrefab, gunEndPositionL.position, Quaternion.Euler(0, 180, 0));
            //audioSource.PlayOneShot(audioClip);
            timeSinceLastShot = 0f;
        }
    }
    public void HittedByBullet()
    {
        if ((dropController.shieldIsActive == true) || (dropController.IFrameIsActive == true))
        {

        }
        else
        {
            //GameManager.uiManager.DisableHpSprite(hp);
            playerHP -= 1;
            dropController.IFrameActive();
            //Debug.Log("Zosta�e� trafiony.");
        }

    }
    public void PlayerArrival()
    {
        arrivalDuration += Time.deltaTime;
        if (arrivalDuration >= arrivalDurationMax)
        {
            playerCanMove = true;
            playerArrived = true;
        }
        else
        {
            transform.Translate(playerArrivalSpeed * Time.deltaTime * Vector2.right, Space.World);
        }
    }

}
