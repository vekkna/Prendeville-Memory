using UnityEngine;
using System.Collections;

public class WelcomeScreenScript : MonoBehaviour {

    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}