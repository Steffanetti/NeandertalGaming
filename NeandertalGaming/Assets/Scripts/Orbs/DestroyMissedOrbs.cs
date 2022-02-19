using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissedOrbs : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.tag == "BlueOrb") {
            ScoreUpdater.orbScore -= 1;
        } else if (other.tag == "GreenOrb") {
            ScoreUpdater.orbScore -= 10;
        }

        other.gameObject.SetActive(false);
    }
}
