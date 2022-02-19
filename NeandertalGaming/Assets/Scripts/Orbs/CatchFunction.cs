using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFunction : MonoBehaviour
{
    public GameObject leftPlatform;
    public GameObject midPlatform;
    public GameObject rightPlatform;
    public bool activePlat;

    public void leftPlat() {
        if (activePlat == false) {
            activePlat = true;
            leftPlatform.SetActive(true);
            StartCoroutine(LeftReset());
        }
    }

    public void midPlat() {
        if (activePlat == false) {
            activePlat = true;
            midPlatform.SetActive(true);
            StartCoroutine(MidReset());
        }
    }

    public void rightPlat() {
        if (activePlat == false) {
            activePlat = true;
            rightPlatform.SetActive(true);
            StartCoroutine(RightReset());
        }
    }

    IEnumerator LeftReset() {
        yield return new WaitForSeconds(0.5f);
        leftPlatform.SetActive(false);
        activePlat = false;
    }

    IEnumerator MidReset() {
        yield return new WaitForSeconds(0.5f);
        midPlatform.SetActive(false);
        activePlat = false;
    }

    IEnumerator RightReset() {
        yield return new WaitForSeconds(0.5f);
        rightPlatform.SetActive(false);
        activePlat = false;
    }
}
