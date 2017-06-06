﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
    private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private Rigidbody2D thisRigid;

	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
        thisRigid = GetComponent<Rigidbody2D>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update()
	{
		if(!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}

		if (Input.GetMouseButton(0)) {
		hasStarted = true;
		thisRigid.velocity = new Vector2 (2f, 10f);
		}


	}

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted) {
            SoundManager.SFX["Bounce"].Play();
            thisRigid.velocity += tweak;
        }
    }
}
