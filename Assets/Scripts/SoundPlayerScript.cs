using UnityEngine;
using System.Collections;

public class SoundPlayerScript : MonoBehaviour {

    AudioClip[] clips;
    AudioSource audioSource;

    void Start() {
        clips = Resources.LoadAll<AudioClip>("Mmms");
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (!audioSource.isPlaying) {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}