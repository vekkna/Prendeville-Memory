using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameSetupScript : MonoBehaviour {

    public GameObject[] buttons;

    void Start() {

        buttons = GameObject.FindGameObjectsWithTag("Button");

        #region POPULATE BUTTONS

        // Load all the mp3s in the "Sounds" folder into a List of clips, inserting each into a random position
        var allMP3s = new List<AudioClip>();
        foreach (AudioClip mp3 in Resources.LoadAll<AudioClip>("Sounds")) {
            allMP3s.Insert(Random.Range(0, allMP3s.Count), mp3);
        }
        // Get the first eight clips (alreay randomised) and add two copies of each to a clips list to be used in this game
        var clips = new List<AudioClip>();
        for (int i = 0; i < buttons.Length / 2; i++) {
            clips.Add(allMP3s[i]);
            clips.Add(allMP3s[i]);
        }
        // Add each one of the sixteen clips to random button
        foreach (GameObject button in buttons) {
            int index = Random.Range(0, clips.Count);
            button.GetComponent<AudioSource>().clip = clips[index];
            clips.RemoveAt(index);
        }
        #endregion
    }
}