using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherScript : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject mainCamera;
	public KeyCode switchKey;

	public static GameObject currentParent;

	public enum CurrentPlayer{
		PLAYER1,
		PLAYER2
	}

	CurrentPlayer currentPlayer;
	// Use this for initialization
	void Start () {
		currentPlayer = CurrentPlayer.PLAYER1;
		currentParent = player1;
		switchKey = KeyCode.Q;
	}
	
	// Update is called once per frame
	void Update () {
		SwitchPlayer (switchKey);	
	}

	public void SwitchPlayer(KeyCode key){
		if (Input.GetKeyDown(key)) {
			if (currentPlayer == CurrentPlayer.PLAYER1) {
				mainCamera.transform.SetParent (player2.transform);
				mainCamera.transform.position = player2.transform.position;
				player1.GetComponent<FPSController> ().enabled = false;
				player2.GetComponent<FPSController> ().enabled = true;
				currentPlayer = CurrentPlayer.PLAYER2;
				currentParent = player2;
				return;
			}

			if (currentPlayer == CurrentPlayer.PLAYER2) {
				mainCamera.transform.SetParent (player1.transform);
				mainCamera.transform.position = player1.transform.position;
				player2.GetComponent<FPSController> ().enabled = false;
				player1.GetComponent<FPSController> ().enabled = true;
				currentPlayer = CurrentPlayer.PLAYER1;
				currentParent = player1;
 				return;
			}
		}
	}
}
