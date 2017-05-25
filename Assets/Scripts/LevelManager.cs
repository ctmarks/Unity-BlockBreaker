using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string sceneName){
        Brick.breakableCount = 0;
		Debug.Log("Level load requested for: " + sceneName);
		SceneManager.LoadScene(sceneName);
	}

	public void LoadNextLevel(){
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		print("Load next level");
	}

	public void Quit(){
		Debug.Log("Quit Application");
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
        } else if (!Application.isEditor) {
            Application.Quit();
        }
		
	}

    public void BrickDestroyed() {
        if (Brick.breakableCount <= 0) {
            LoadNextLevel();
        }
    }
}
