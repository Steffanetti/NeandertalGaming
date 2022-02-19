using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject actualScore;
    public GameObject bestScore;
    public GameObject level;

    public void Pause() {
        pauseMenu.SetActive(true);
        actualScore.GetComponent<Text>().text = "Actual Score : " + ScoreUpdater.orbScore;
        Time.timeScale = 0f;
    }

    public void resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
