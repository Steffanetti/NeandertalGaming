using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissedOrbs : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        other.gameObject.SetActive(false);
    }
}
