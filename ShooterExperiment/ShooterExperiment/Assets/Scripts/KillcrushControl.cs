﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillcrushControl : MonoBehaviour {

	private GameObject lastCheckpoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER1) {
//			lastCheckpoint = CheckpointControl.chkDictP1 [CheckpointControl.chkLastP1];
//		} else {
//			lastCheckpoint = CheckpointControl.chkDictP2 [CheckpointControl.chkLastP2];
//		}
	}

	void OnCollisionEnter (Collision coll)
	{
		if (coll.gameObject.name == "Player") {		
			lastCheckpoint = CheckpointControl.chkDictP1 [CheckpointControl.chkLastP1];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
		} 

		if (coll.gameObject.name == "Player2") {
			lastCheckpoint = CheckpointControl.chkDictP2 [CheckpointControl.chkLastP2];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
		}
	}
}
