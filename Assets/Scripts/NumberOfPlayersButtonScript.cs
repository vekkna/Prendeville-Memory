using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberOfPlayersButtonScript : MonoBehaviour {

    void Start() {
        GetComponent<Button>().onClick.AddListener(() => OnClick());
    }

    public void OnClick() {
        PersistantDateScript.numberOfPlayers = int.Parse(GetComponentInChildren<Text>().text);
        Application.LoadLevel(1);
    }
}