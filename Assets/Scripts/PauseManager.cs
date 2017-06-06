using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour {

    public GameObject optionsMenu;
    public static bool isPaused = false;

    public SoundManager soundManager;

    void start() {
    }

    void Update() {
        // Enable pause menu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
            Pause();
        }

        // disable pause menu
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) {
            Time.timeScale = 1;
            //pauseMenu.SetActive(false);
            Cursor.visible = false;
            isPaused = false;
        }
    }

    public void Pause() {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        //pauseMenu.SetActive(true);
        isPaused = !isPaused;
        Cursor.visible = !Cursor.visible;
        soundManager.TogglePauseSnapshot(isPaused);
       }

    //public void lowPass() {
    //    if(Time.timeScale == 0) {
    //        paused.TransitionTo(.01f);
    //    } else {
    //        unPaused.TransitionTo(.01f);
    //    }
    //}
}
