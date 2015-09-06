/* To be put on Text that you want to blink*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkScript : MonoBehaviour {

    public float blinkSpeed;
    WaitForSeconds delay;
    Text text;
    CanvasGroup canvasGroup;
    public bool isBlinking;

    void Start() {
        delay = new WaitForSeconds(blinkSpeed);
        text = GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink() {
        while (isBlinking) {
            yield return delay;
            if (text != null)
                text.enabled = !text.enabled;
            else if (canvasGroup != null) {
                canvasGroup.alpha = (canvasGroup.alpha == 1) ? 0 : 1;
            }
        }
    }
}