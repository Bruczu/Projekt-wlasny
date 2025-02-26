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
    // Start is called before the first frame update
    void Start()
    {
        UIController.endGameController = this;
        EnemySpawner.endGameController = this;
        EnemySpawner2.endGameController = this;
        gamePhase = 2;
    }

    // Update is called once per frame
    void Update()
    {
        EndTrigger();
        GamePhaseActive();
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

    }
}
