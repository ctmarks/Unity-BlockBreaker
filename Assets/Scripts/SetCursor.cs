using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour {

    public Texture2D cursorTexture;

	// Use this for initialization
	void Start () {
        cursorTexture.Resize(16, 16);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
	}
	

}
