using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public AudioClip crack;

    private LevelManager levelManager;
    private bool isBreakable;
    private int timesHit;



    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if (isBreakable) {
            breakableCount++;
        }

        levelManager = FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable) {
            HandleHits();
        }
	}

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            breakableCount--;
            levelManager.BrickDestroyed();
            print(breakableCount);
            Destroy(gameObject);
        } else {
            LoadSprites();
        }
    }

	//TODO Remove this method once we can actully win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        
    }
}
