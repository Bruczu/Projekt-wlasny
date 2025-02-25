using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public static PlayerController playerController;
    public static UIController uicontroller;

    public bool playerWon;
    // Start is called before the first frame update
    void Start()
    {
        UIController.endGameController = this;
    }

    // Update is called once per frame
    void Update()
    {
        EndTrigger();
    }
    public void EndTrigger()
    {
        if (playerController.playerHP <= 0)
        {
            uicontroller.GoEndMenu();
        }
        if (playerController.points >= 1000)
        {
            playerWon = true;
            uicontroller.GoEndMenu();
        }
    }
}
