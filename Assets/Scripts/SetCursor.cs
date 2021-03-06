﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour {

    public Texture2D cursorTexture;

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
	}
	

}
