using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : PlayerSwitcherScript {

	bool gameIsPaused;
	private CursorLockMode cursorLockMode;
	// Use this for initialization
	void Start () {
		gameIsPaused = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(playerIsNow == PresentPlayer.GOD || gameIsPaused){
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			// Cursor.visible = false;
		}		
	}

}
