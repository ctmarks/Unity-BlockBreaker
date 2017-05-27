using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
    }

	// Update is called once per frame
	void Update () {
        if(!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    void MoveWithMouse() {
        if (Pause.isPaused) {

        } else {
            Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

            float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16f;

            paddlePos.x = mousePosInBlocks;
            this.transform.position = paddlePos;
            this.transform.position = new Vector3(Mathf.Clamp(paddlePos.x, 1.5f, 14.5f), this.transform.position.y, this.transform.position.z);
        }
        
    }

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = ballPos.x;
        this.transform.position = paddlePos;
        this.transform.position = new Vector3(Mathf.Clamp(ballPos.x, 1.5f, 14.5f), this.transform.position.y, this.transform.position.z);
    }
}
