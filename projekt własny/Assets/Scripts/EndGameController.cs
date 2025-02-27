using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public static PlayerController playerController;
    public static UIController uicontroller;
    public int gamePhase;
    public float phaseTime, maxPhaseTime;
    public int pointsNeededToBossFight;

    public bool playerWon;

    public float getReadyCountdown;
    public GameObject Countdown3;
    public GameObject Countdown2;
    public GameObject Countdown1;
    public GameObject CountdownGo;
    // Start is called before the first frame update
    void Start()
    {
        UIController.endGameController = this;
        EnemySpawner.endGameController = this;
        EnemySpawner2.endGameController = this;
        BossSpawner.endGameController = this;
        gamePhase = 0;
        Countdown1.SetActive(false);
        Countdown2.SetActive(false);
        Countdown3.SetActive(false);
        CountdownGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EndTrigger();
        GamePhaseActive();
        GetReadySequence();
    }
    public void EndTrigger()
    {
        if (playerController.playerHP <= 0)
        {
            uicontroller.GoEndMenu();
        }
        if (playerController.points >= playerController.pointsNeeded)
        {
            playerWon = true;
            uicontroller.GoEndMenu();
        }
    }
    public void GamePhaseActive()
    {
        if (gamePhase == 1)
        {
            phaseTime += Time.deltaTime;
            if (phaseTime >= maxPhaseTime)
            {
                phaseTime = 0;
                gamePhase = 2;
            }
            if (playerController.points >= pointsNeededToBossFight)
            {
                phaseTime = 0;
                gamePhase = 3;
            }
        }
        if (gamePhase == 2)
        {
            phaseTime += Time.deltaTime;
            if (phaseTime >= maxPhaseTime)
            {
                phaseTime = 0;
                gamePhase = 1;
            }
            if(playerController.points >= pointsNeededToBossFight)
            {
                phaseTime = 0;
                gamePhase = 3;
            }
        }
        if (gamePhase == 3)
        {

        }
    }
    public void GetReadySequence()
    {
        if (playerController.playerArrived == true)
        {
            getReadyCountdown += Time.deltaTime;
            if ((getReadyCountdown <= 1))
            {
                Countdown3.SetActive(true);
            }
            if ((getReadyCountdown >= 1) && (getReadyCountdown < 2))
            {
                Countdown3.SetActive(false);
                Countdown2.SetActive(true);
            }
            if ((getReadyCountdown >= 2) && (getReadyCountdown < 3))
            {
                Countdown2.SetActive(false);
                Countdown1.SetActive(true);
            }
            if ((getReadyCountdown >= 3) && (getReadyCountdown < 4))
            {
                Countdown1.SetActive(false);
                CountdownGo.SetActive(true);
            }
            if (getReadyCountdown >= 4)
            {
                CountdownGo.SetActive(false);
                playerController.playerArrived = false;
                getReadyCountdown = 0;
                gamePhase = 1;
            }
        }
    }
}
