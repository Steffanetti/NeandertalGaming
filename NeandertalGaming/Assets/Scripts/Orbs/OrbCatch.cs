using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCatch : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.tag == "BlueOrb") {
            ScoreUpdater.orbScore += 1;
        } else if (other.tag == "GreenOrb") {
            ScoreUpdater.orbScore += 100;
        } else if (other.tag == "RedOrb") {
            ScoreUpdater.orbScore -= 1;
        }
        other.gameObject.SetActive(false);
    }
}
