using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timeDisplay;
    public bool countingDown = false;
    public int currentSeconds = 10;
    public bool isZero = false;
    public GameObject splashBg;
    public GameObject globalScripts;
    public GameObject tapPlayButton;
    public GameObject finalScore;
    public GameObject bestScore;
    public GameObject level;
    public GameObject tapToBeginText;
    public GameObject pauseButton;
    void Update()
    {
        if (countingDown == false && isZero == false) {
            countingDown = true;
            StartCoroutine(SubstractSeconds());
        }
        if (isZero == true) {
            finalScore.GetComponent<Text>().text = "Score : " + ScoreUpdater.orbScore;
            StartCoroutine(EndGame());
        }
        if (ScoreUpdater.orbScore < 0) {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator SubstractSeconds() {
        yield return new WaitForSeconds(1);
        currentSeconds -= 1;
        if (currentSeconds == 0) {
            isZero = true;
        }
        timeDisplay.GetComponent<Text>().text = "Time : " + currentSeconds;
        countingDown = false;
    }
    IEnumerator EndGame() {
        SaveManager.Instance.Load();
        if (SaveManager.Instance.state.bestScore < ScoreUpdater.orbScore) {
            SaveManager.Instance.state.bestScore = ScoreUpdater.orbScore;
            SaveManager.Instance.state.level++;
            SaveManager.Instance.Save();
        }
        pauseButton.SetActive(false);
        splashBg.SetActive(true);
        splashBg.GetComponent<Animator>().Play("SplashFadeIn");
        globalScripts.GetComponent<OrbGenerate>().enabled = false;
        yield return new WaitForSeconds(1.2f);
        finalScore.SetActive(true);
        bestScore.GetComponent<Text>().text = "Best Score : " + SaveManager.Instance.state.bestScore;
        level.GetComponent<Text>().text = "Level : " + SaveManager.Instance.state.level;
        bestScore.SetActive(true);
        level.SetActive(true);
        tapToBeginText.GetComponent<Text>().text = "Well done ! Next Difficulty";
        tapToBeginText.SetActive(true);
        tapPlayButton.SetActive(true);
        currentSeconds = 10;
        isZero = false;
        ScoreUpdater.orbScore = 0;
        yield return new WaitForSeconds(0.1f);
        globalScripts.GetComponent<Timer>().enabled = false;
    }

    IEnumerator GameOver() {
        pauseButton.SetActive(false);
        splashBg.SetActive(true);
        splashBg.GetComponent<Animator>().Play("SplashFadeIn");
        globalScripts.GetComponent<OrbGenerate>().enabled = false;
        yield return new WaitForSeconds(1.2f);
        finalScore.SetActive(true);
        bestScore.GetComponent<Text>().text = "Best Score : " + SaveManager.Instance.state.bestScore;
        level.GetComponent<Text>().text = "Level : " + SaveManager.Instance.state.level;
        bestScore.SetActive(true);
        level.SetActive(true);
        tapToBeginText.GetComponent<Text>().text = "Too bad, try again if you want !";
        tapToBeginText.SetActive(true);
        tapPlayButton.SetActive(true);
        currentSeconds = 10;
        isZero = false;
        ScoreUpdater.orbScore = 0;
        yield return new WaitForSeconds(0.1f);
        globalScripts.GetComponent<Timer>().enabled = false;

    }
}
