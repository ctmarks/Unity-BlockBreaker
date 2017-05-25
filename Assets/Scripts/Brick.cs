using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smoke;
    public int maxHits;

    private Color spriteColor;
    private LevelManager levelManager;
    private bool isBreakable;
    private int timesHit;
    private SpriteRenderer cracked;



    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if (isBreakable) {
            breakableCount++;
        }

        cracked = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteColor = GetComponent<SpriteRenderer>().color;
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
        if (timesHit >= maxHits) {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        } else {
            LoadSprites();
        }
    }

    void PuffSmoke () {
        GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
        var main = smokePuff.GetComponent<ParticleSystem>().main;
        main.startColor = spriteColor;
    }

	//TODO Remove this method once we can actully win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}

    void LoadSprites() {
        cracked.enabled = true;
    }
}
