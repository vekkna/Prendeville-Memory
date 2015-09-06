using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class GameScript : MonoBehaviour {

    public int numberOfPlayers;

    int currentPlayer = 0;
    public int currentClick = 1;
    GameObject lastButtonClicked;
    Text instructions;
    public bool clipIsPlaying;
    public int[] scores;
    int numberOfPairs, numberOfButtons;
    string[] players;
    public GameObject soundplayer;
    public GameObject fireworks;
    List<Button> buttons;
    public int bigFontSize;

    void Start() {
        numberOfPlayers = PersistantDateScript.numberOfPlayers;
        instructions = GameObject.Find("Instructions").GetComponent<Text>();
        scores = new int[numberOfPlayers];
        numberOfButtons = GameObject.FindGameObjectsWithTag("Button").Length;
        players = new string[] { "one", "two", "three", "four" };
        GameObject[] but = GameObject.FindGameObjectsWithTag("Button");
        buttons = new List<Button>();
        foreach (GameObject b in but) {
            buttons.Add(b.GetComponent<Button>());
        }
        UpdateTurnText();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.LoadLevel(0);
        }
    }

    public void ResolveTurn(GameObject button) {
        if (currentClick == 1) {
            lastButtonClicked = button;
            currentClick = 2;
        }
        else {
            if (lastButtonClicked.GetComponent<AudioSource>().clip == button.GetComponent<AudioSource>().clip) {
                scores[currentPlayer] += 1;
                button.transform.parent.gameObject.GetComponentInChildren<Text>().text = (currentPlayer + 1).ToString();
                lastButtonClicked.transform.parent.gameObject.GetComponentInChildren<Text>().text = (currentPlayer + 1).ToString();
                RemoveButton(button);
                RemoveButton(lastButtonClicked);
                //Destroy(button);
                //Destroy(lastButtonClicked);

                numberOfPairs += 1;

                if (numberOfPairs == numberOfButtons / 2) {
                    BeginCelebrations();
                    soundplayer.SetActive(true);
                    int highScore = scores.Max();
                    List<int> winners = new List<int>();
                    for (int i = 0; i < scores.Length; i++) {
                        if (scores[i] == highScore) {
                            winners.Add(i);
                        }
                    }
                    instructions.fontSize = bigFontSize;
                    if (winners.Count == 1) {
                        instructions.text = "Player " + players[winners[0]] + " wins!";
                    }
                    else {
                        instructions.text = "Draw!";
                    }
                }
            }
            else {
                currentPlayer++;
                currentPlayer = currentPlayer % numberOfPlayers;
                instructions.GetComponent<TextAnimationScript>().isSlidingOut = true;
            }
            currentClick = 1;
            lastButtonClicked.GetComponent<ButtonClickScript>().ResetColour();
            button.GetComponent<ButtonClickScript>().ResetColour();
        }
    }

    public void UpdateTurnText() {
        instructions.GetComponent<Text>().text = "Player " + players[currentPlayer] + "'s turn";
    }

    public void ToggleButtons() {
        foreach (Button b in buttons) {
            b.interactable = !b.interactable;
        }
    }

    void BeginCelebrations() {
        GameObject.Find("Instructions").GetComponent<BlinkScript>().isBlinking = true;
        fireworks.transform.position = new Vector3(0, 0, 0);
    }

    void RemoveButton(GameObject button) {
        Destroy(button);
        buttons.Remove(button.GetComponent<Button>());
    }
}