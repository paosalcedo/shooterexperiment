using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneControl : MonoBehaviour {

	private GameObject lastCheckpoint;

	void Update(){
		
//		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER1) {
//			lastCheckpoint = CheckpointControl.chkDictP1 [CheckpointControl.chkLastP1];
//		} else {
//			lastCheckpoint = CheckpointControl.chkDictP2 [CheckpointControl.chkLastP2];
//		}

	}

	void OnTriggerEnter(Collider coll){
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
