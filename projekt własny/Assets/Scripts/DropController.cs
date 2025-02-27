using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public bool shieldIsActive, DMGBoostIsActive, PiercingBulletsIsActive, IFrameIsActive;
    public float shieldTime, DMGBoostTime, PiercingBulletsTime, IFrameTime;
    public float howLongBoost, howLongIFrame;
    public static PlayerController playerController;
    public GameObject shieldSprite, DMGBoostSprite, PiercingBulletsSprite;

    void Start()
    {
        PlayerController.dropController = this;
        DropMovementController.dropController = this;
        DropShipController.dropController = this;
        BulletController.dropController= this;
        EnemyController.dropController = this;
        Enemy2Controller.dropController = this;
        BossIdleMovement.dropController = this;
        shieldSprite.SetActive(false);
        DMGBoostSprite.SetActive(false);
        PiercingBulletsSprite.SetActive(false);
    }

    void Update()
    {
        if (IFrameIsActive == true)
        {
            IFrameTime += Time.deltaTime;
            if (IFrameTime >= howLongIFrame)
            {
                IFrameIsActive = false;
                shieldSprite.SetActive(false);
                IFrameTime = 0;
            }
        }
        if (shieldIsActive == true)
        {
            shieldTime += Time.deltaTime;
            if (shieldTime >= howLongBoost)
            {
                shieldIsActive = false;
                shieldSprite.SetActive(false);
                shieldTime = 0;
            }
        }
        if (DMGBoostIsActive == true)
        {
            DMGBoostTime += Time.deltaTime;
            if (DMGBoostTime >= howLongBoost)
            {
                DMGBoostIsActive = false;
                DMGBoostSprite.SetActive(false);
                DMGBoostTime = 0;
            }
        }
        if (PiercingBulletsIsActive == true)
        {
            PiercingBulletsTime += Time.deltaTime;
            if (PiercingBulletsTime >= howLongBoost)
            {
                PiercingBulletsIsActive = false;
                PiercingBulletsSprite.SetActive(false);
                PiercingBulletsTime = 0;
            }
        }
    }
    public void HealthUp()
    {
        playerController.playerHP+= 2;
        if (playerController.playerHP > playerController.maxPlayerHP)
        {
            playerController.playerHP = playerController.maxPlayerHP;
        }
    }
    public void ShieldActive()
    {
        shieldIsActive = true;
        shieldSprite.SetActive(true);
    }
    public void DMGBoost()
    {
        DMGBoostIsActive = true;
        DMGBoostSprite.SetActive(true);
    }
    public void PiercingBullets()
    {
        PiercingBulletsIsActive = true;
        PiercingBulletsSprite.SetActive(true);
    }
    public void IFrameActive()
    {
        IFrameIsActive = true;
        shieldSprite.SetActive(true);
    }
}
