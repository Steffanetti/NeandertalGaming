using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OCMBegins : MonoBehaviour
{
    public GameObject mainLogo;
    public GameObject[] menuText;
    public GameObject splashBg;
    public GameObject globalScripts;
    public GameObject countdownText;
    public GameObject tapButton;
    public GameObject finalScore;
    public GameObject bestScore;
    public GameObject level;
    public GameObject pauseButton;


    void Start()
    {
        StartCoroutine(StartupGame());
    }

    IEnumerator StartupGame() {
        yield return new WaitForSeconds(1);
        mainLogo.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        mainLogo.SetActive(false);
        menuText[0].SetActive(true);
        menuText[1].SetActive(true);
        tapButton.SetActive(true);
    }

    public void tapToStart() {
        tapButton.SetActive(false);
        menuText[0].SetActive(false);
        menuText[1].SetActive(false);
        splashBg.GetComponent<Animator>().Play("SplashFadeOut");
        StartCoroutine(BeginGame());
    }

    IEnumerator BeginGame() {
        finalScore.SetActive(false);
        bestScore.SetActive(false);
        level.SetActive(false);
        yield return new WaitForSeconds(1);
        countdownText.SetActive(true);
        yield return new WaitForSeconds(1);
        countdownText.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1);
        countdownText.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1);
        tapButton.SetActive(false);
        splashBg.SetActive(false);
        pauseButton.SetActive(true);
        countdownText.SetActive(false);
        countdownText.GetComponent<Text>().text = "3";
        globalScripts.GetComponent<Timer>().enabled = true;
        globalScripts.GetComponent<OrbGenerate>().enabled = true;
    }

}
