using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClickScript : MonoBehaviour {

    AudioSource sound;
    bool isDown;
    GameScript gameScript;
    Color originalColor;
    Image image;
    Color activeColor;

    void Start() {
        sound = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(() => OnClick());
        gameScript = GameObject.Find("Main Camera").GetComponent<GameScript>();
        image = GetComponent<Image>();
        originalColor = image.color;
        activeColor = Color.grey;
    }

    IEnumerator ChangeColour() {

        image.color = activeColor;
        yield return new WaitForSeconds(sound.clip.length);
        gameScript.ResolveTurn(gameObject);

        gameScript.ToggleButtons();

        if (gameScript.currentClick == 1)
            image.color = originalColor;
    }

    public void ResetColour() {
        image.color = originalColor;
    }

    void OnClick() {

        gameScript.ToggleButtons();

        gameScript.clipIsPlaying = true;
        sound.Play();
        StartCoroutine(ChangeColour());
    }
}