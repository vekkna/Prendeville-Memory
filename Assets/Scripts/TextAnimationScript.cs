using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAnimationScript : MonoBehaviour {

    RectTransform tr;
    Vector2 startingPos;
    public Vector2 leftPos, rightPos;
    public bool isSlidingOut, isSlidingIn;
    public float slidingSpeed;
    GameScript gameScript;

    void Start() {
        tr = GetComponent<RectTransform>();
        startingPos = tr.position;
        gameScript = GameObject.Find("Main Camera").GetComponent<GameScript>();
    }

    public void Animate() {
        isSlidingOut = true;
    }

    void Update() {
        if (isSlidingOut) {
            if (tr.position.x > leftPos.x) {
                tr.position = new Vector2(((tr.position.x - slidingSpeed * Time.deltaTime)), startingPos.y);
            }
            else {
                isSlidingOut = false;
                tr.position = rightPos;
                isSlidingIn = true;
                gameScript.UpdateTurnText();
            }
        }
        if (isSlidingIn) {
            if (tr.position.x > startingPos.x) {
                tr.position = new Vector2(((tr.position.x - slidingSpeed * Time.deltaTime)), startingPos.y);
            }
            else {
                isSlidingIn = false;
                tr.position = startingPos;
            }
        }
    }
}
