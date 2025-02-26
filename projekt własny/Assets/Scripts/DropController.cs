using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public bool shieldIsActive, DMGBoostIsActive, PiercingBulletsIsActive;
    public float shieldTime, DMGBoostTime, PiercingBulletsTime;
    public float howLongBoost;
    public static PlayerController playerController;

    void Start()
    {
        PlayerController.dropController = this;
    }


    public void HealthUp()
    {
        playerController.playerHP+= 2;
    }
    public void ShieldActive()
    {
        shieldIsActive = true;
        shieldTime += Time.deltaTime;
        if (shieldTime == howLongBoost)
        {
            shieldIsActive = false;
            shieldTime = 0;
        }
    }
    public void DMGBoost()
    {
        DMGBoostIsActive = true;
        DMGBoostTime += Time.deltaTime;
        if (DMGBoostTime == howLongBoost)
        {
            DMGBoostIsActive = false;
            DMGBoostTime = 0;
        }
    }
    public void PiercingBullets()
    {
        PiercingBulletsIsActive = true;
        PiercingBulletsTime += Time.deltaTime;
        if (PiercingBulletsTime == howLongBoost)
        {
            PiercingBulletsIsActive = false;
            PiercingBulletsTime = 0;
        }
    }
}
