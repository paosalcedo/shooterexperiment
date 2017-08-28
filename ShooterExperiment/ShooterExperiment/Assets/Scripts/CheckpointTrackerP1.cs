using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrackerP1 : MonoBehaviour {

	public int chkKey; 

	// Use this for initialization
	void Start () {
		CheckpointControl.chkDictP1.Add (chkKey, this.gameObject);	
	}

	void OnTriggerEnter(){
		Debug.Log ("Player 1 has reached checkpoint " + chkKey + "!");		

		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER1) {
			CheckpointControl.chkLastP1 = chkKey;
		}
	}
}
