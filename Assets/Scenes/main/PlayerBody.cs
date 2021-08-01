using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject dot;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Time.timeScale = 0;
            dot.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }
}
