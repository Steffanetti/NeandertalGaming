using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGenerate : MonoBehaviour
{
    public GameObject[] orbFall;
    public bool genOrb = false;
    public int orbLoc;
    public int orbCol;
    public float xPos;

    void Update() {
        if (genOrb == false) {
            genOrb = true;
            orbLoc = Random.Range(1, 4);
            SaveManager.Instance.Load();
            if (SaveManager.Instance.state.level == 1) {
                orbCol = Random.Range(0, 2);
            } else {
                orbCol = Random.Range(0, 3);
            }
            if (orbLoc == 1) {
                xPos = -1.5f;
            } else if (orbLoc == 2) {
                xPos = 0;
            } else if (orbLoc == 3) {
                xPos = 1.5f;
            }
            StartCoroutine(OrbFalling());
        }
    }

    IEnumerator OrbFalling() {
        Instantiate(orbFall[orbCol], new Vector3(xPos, 7, -3), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        genOrb = false;
    }
}
