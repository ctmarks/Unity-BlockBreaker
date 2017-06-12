using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public Color flashColor;
    public float flashTime = 0.1f;
    public int maxHits;
    public GameObject stars;

    private Color spriteColor;
    private LevelManager levelManager;
    private bool isBreakable;
    private int timesHit;
    private int spriteIndex;
    private SpriteRenderer spriteRenderer;
    private Animator animator;



    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if (isBreakable) {
            breakableCount++;
        }



        timesHit = 0;

        spriteIndex = 0;

        spriteRenderer = this.GetComponent<SpriteRenderer>();

        this.GetComponent<SpriteRenderer>().color = Color.white;

        spriteColor = GetComponent<SpriteRenderer>().color;

        levelManager = FindObjectOfType<LevelManager>();

        animator = this.GetComponent<Animator>();
	}

	void OnCollisionEnter2D (Collision2D col) {
        if (isBreakable) {
            HandleHits();
        }
	}


    IEnumerator spriteFlasher() {
        spriteRenderer.color = flashColor;

        yield return new WaitForSeconds(flashTime);

        //spriteRenderer.color = spriteColor;
    }

    void HandleHits() {
        GetComponent<SpriteRenderer>().color = Color.white;
        //animator.Play("DamageFlash");
        //StartCoroutine(spriteFlasher());
        SoundManager.SFX["Crack"].Play();
        timesHit++;
        if (timesHit >= maxHits) {
            PuffSmoke();
            //animator.Play("BrickTranslate");
            //animator.Play("BrickRotate");
            animator.Play("BrickDeath");
            breakableCount--;
            print(breakableCount);
            levelManager.BrickDestroyed();
        } else {
            LoadSprites();
        }
    }

    void PuffSmoke () {
        GameObject smokePuff = Instantiate(stars, this.transform.position, Quaternion.identity) as GameObject;
        var main = smokePuff.GetComponent<ParticleSystem>().main;
        main.startColor = spriteColor;
    }

	//TODO Remove this method once we can actully win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}

    void LoadSprites() {
        spriteRenderer.sprite = hitSprites[spriteIndex];
        spriteIndex++;
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
