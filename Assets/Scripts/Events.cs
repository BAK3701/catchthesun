using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public static bool isPause;
    public static bool isRespawnScore;
    public static bool isRespawnPlayer;
    [SerializeField] GameObject pausePanel;
    private void Start()
    {
        isPause = false;
    }
    public void replayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void pauseGame()
    {
        isPause = true;
        pausePanel.SetActive(true);
    }
    public void continueGame()
    {
        isPause = false;
        pausePanel.SetActive(false);
    }
    public void respawnChar()
    {
        isRespawnScore = true;
        isRespawnPlayer = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void goMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
