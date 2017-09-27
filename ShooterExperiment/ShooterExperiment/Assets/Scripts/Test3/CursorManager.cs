using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : PlayerSwitcherScript {

	public enum CanvasState{
		VISIBLE,
		INVISIBLE
	}

	CanvasState canvasState;

	private KeyCode toggleCanvasKey;
	public GameObject playbackCanvas;
	bool gameIsPaused;
	private CursorLockMode cursorLockMode;
	// Use this for initialization
	void Start () {
		toggleCanvasKey = KeyCode.Tab;
		canvasState = CanvasState.INVISIBLE;
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

		switch (canvasState){
			case CanvasState.INVISIBLE:
				ShowPlaybackCanvas(toggleCanvasKey);
				break;
			case CanvasState.VISIBLE:
				HidePlaybackCanvas(toggleCanvasKey);
				break;
			default:
				break;
		}
	}

	private bool playbackCanvasIsVisible = false;
	public void HidePlaybackCanvas(KeyCode key){
		if(Input.GetKeyDown(key)){
			canvasState = CanvasState.INVISIBLE;
			playbackCanvas.SetActive(false);
		}
	}

	public void ShowPlaybackCanvas(KeyCode key){
		if(Input.GetKeyDown(key)){
			canvasState = CanvasState.VISIBLE;
			playbackCanvas.SetActive(true);
		}
	}



}
