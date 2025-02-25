using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    /*public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;

    public List<GameObject> hpPointsList = new List<GameObject>();
    */
    public PlayerController playerController;
    public TextMeshProUGUI pointsValue;

    private bool isPaused;
    public GameObject pausePanel;
    public GameObject confirmationPanel;

    void Start()
    {
        pausePanel.SetActive(false);
        confirmationPanel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        pointsValue.text = "Points: " + playerController.points.ToString();

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

}
