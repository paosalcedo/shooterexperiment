using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneControl : MonoBehaviour {

	GameObject lastCheckpoint;

	void OnTriggerEnter(Collider coll){
		lastCheckpoint = CheckpointControl.chkDict[CheckpointControl.chkLast];
		RespawnControl.Respawn (coll.gameObject, lastCheckpoint);	
	}

	void OnCollisionEnter(Collision coll){
		lastCheckpoint = CheckpointControl.chkDict[CheckpointControl.chkLast];
		RespawnControl.Respawn (coll.gameObject, lastCheckpoint);	

	}
}
