using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits;

	private LevelManager levelManager;

	public int timesHit;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		timesHit++;
		if (timesHit >= maxHits) {
			Destroy(gameObject);
		}
	}

	//TODO Remove this method once we can actully win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
