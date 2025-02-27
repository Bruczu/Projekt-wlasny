using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static EndGameController endGameController;
    public static BossSpawner bossSpawner;
    public PlayerController playerController;
    public TextMeshProUGUI pointsValue;
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI bossHPUIText;
    public GameObject bossHPUI;

    private bool isPaused;
    public GameObject pausePanel;
    public GameObject confirmationPanel;
    public GameObject endGamePanel;
    public GameObject wonText;
    public GameObject lostText;



    void Start()
    {
        EndGameController.uicontroller = this;
        pausePanel.SetActive(false);
        confirmationPanel.SetActive(false);
        endGamePanel.SetActive(false);
        wonText.SetActive(false);
        lostText.SetActive(false);
        bossHPUI.SetActive(false);

        Time.timeScale = 1;
    }
    void Update()
    {
        pointsValue.text = "Points: " + playerController.points.ToString();
        playerHP.text = "HP: " + playerController.playerHP.ToString();

        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (bossSpawner.bossSpawned == true)
        {
            bossHPUI.SetActive(true);
            bossHPUIText.text = bossSpawner.bossHP.ToString();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        confirmationPanel.SetActive(false);
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        confirmationPanel.SetActive(true);
        isPaused = !isPaused;
    }
    public void Confirmation()
    {
        confirmationPanel.SetActive(true);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoEndMenu()
    {
        Time.timeScale = 0;
        endGamePanel.SetActive(true);
        if (endGameController.playerWon == true)
        {
            wonText.SetActive(true);
        }
        else
        {
            lostText.SetActive(true);
        }
    }
}
