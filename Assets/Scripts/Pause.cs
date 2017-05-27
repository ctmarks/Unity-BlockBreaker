using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;
    public static bool isPaused = false;

    void Update() {
        // Enable pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        isPaused = true;
        }

        // disable pause menu
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        isPaused = false;
        }
    }
}
