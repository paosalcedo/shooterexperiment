using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherScript : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject mainCamera;
	GameObject currentCam;
	public KeyCode switchKey;

	private Quaternion p1_lastRot;
	private Quaternion p2_lastRot;

	public static GameObject currentParent;

	public enum CurrentPlayer{
		PLAYER1,
		PLAYER2
	}

	public static CurrentPlayer currentPlayer;
	// Use this for initialization
	void Start () {
		currentPlayer = CurrentPlayer.PLAYER1;
		currentParent = player1;
//		currentCam = Camera.main.transform.gameObject;
		switchKey = KeyCode.Q;
	}
	
	// Update is called once per frame
	void Update () {
		SwitchPlayer (switchKey);	
	}

	public void SwitchPlayer(KeyCode key){
		if (Input.GetKeyDown(key)) {
			if (currentPlayer == CurrentPlayer.PLAYER1) {
				
//				mainCamera.transform.SetParent (player2.transform);
//				mainCamera.transform.position = player2.transform.position;
//				mainCamera.transform.localPosition = new Vector3 (0f, 1f, 0f);
				//save player 1 rotation
				p1_lastRot = player1.transform.rotation; 
				player1.GetComponent<FPSController> ().enabled = false;
				player1.GetComponentInChildren<Camera> ().enabled = false;
				player2.GetComponent<FPSController> ().enabled = true;
				player2.GetComponentInChildren<Camera> ().enabled = true;
				currentPlayer = CurrentPlayer.PLAYER2;
				player2.transform.rotation = p2_lastRot;
				currentParent = player2;
				
				return;
			}

			if (currentPlayer == CurrentPlayer.PLAYER2) {
//				mainCamera.transform.SetParent (player1.transform);
//				mainCamera.transform.position = player1.transform.position;
//				mainCamera.transform.localPosition = new Vector3 (0f, 1f, 0f);
				p2_lastRot = player2.transform.rotation;
				player2.GetComponent<FPSController> ().enabled = false;
				player2.GetComponentInChildren<Camera> ().enabled = false;
				player1.GetComponent<FPSController> ().enabled = true;
				player1.GetComponentInChildren<Camera> ().enabled = true;
				player1.transform.rotation = p1_lastRot;
				currentPlayer = CurrentPlayer.PLAYER1;
				currentParent = player1;
 				return;
			}
		}
	}
}
