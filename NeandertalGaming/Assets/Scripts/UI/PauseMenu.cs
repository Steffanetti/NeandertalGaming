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
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        SaveManager.Instance.Load();
        actualScore.GetComponent<Text>().text = "Actual Score : " + ScoreUpdater.orbScore;
        bestScore.GetComponent<Text>().text = "Best Score : " + SaveManager.Instance.state.bestScore;
        level.GetComponent<Text>().text = "Level : " + SaveManager.Instance.state.level;
    }

    public void resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
