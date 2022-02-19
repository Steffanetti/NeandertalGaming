using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCatch : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.tag == "BlueOrb") {
            print("blue");
            ScoreUpdater.orbScore += 1;
        } else if (other.tag == "GreenOrb") {
            print("green");
            ScoreUpdater.orbScore += 100;
        } else if (other.tag == "RedOrb") {
            ScoreUpdater.orbScore -= 1;
        }
        other.gameObject.SetActive(false);
    }
}
