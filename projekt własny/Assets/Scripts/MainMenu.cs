using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static PlayerController playerController;
    public GameObject optionsPanel;
    void Start()
    {
        optionsPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Wychodzisz z gry.");
        Application.Quit();
    }

    public void OptionsOn()
    {
        optionsPanel.SetActive(true);
    }
    public void OptionsOff()
    {
        optionsPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
