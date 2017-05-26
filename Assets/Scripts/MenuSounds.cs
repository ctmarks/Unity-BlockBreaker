using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip menuClick;
    public AudioClip menuHover;
    public AudioClip menuStartGame;

	// Use this for initialization
	void Start () {
        audioSource = this.GetComponent<AudioSource>();
	}
	
    public void MenuClick() {
        audioSource.clip = menuClick;
        audioSource.Play();
    }

    public void MenuHover() {
        audioSource.clip = menuHover;
        audioSource.Play();
    }

    public void MenuStartGame() {
        audioSource.clip = menuStartGame;
        audioSource.Play();
    }
}
