using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControl : MonoBehaviour {

	public enum GameState{
		SIMULATION,
		LIVE
	}

	public static GameState gameState;
 	// Use this for initialization
	void Start () {
		gameState = GameState.LIVE;
 	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(gameState);
		// Debug.Log(gameState);
	}

	
}
