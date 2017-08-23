using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherScript : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	public GameObject MainCamera;

	public enum CurrentPlayer{
		PLAYER1,
		PLAYER2
	}

	CurrentPlayer currentPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchPlayer(){
		if (currentPlayer == CurrentPlayer.PLAYER1) {
			MainCamera.transform.SetParent (Player2.transform);	
		}

		if (currentPlayer == CurrentPlayer.PLAYER2) {
			MainCamera.transform.SetParent (Player1.transform);
		}
	}
}
