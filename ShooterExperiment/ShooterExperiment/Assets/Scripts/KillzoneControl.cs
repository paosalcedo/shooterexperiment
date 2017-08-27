using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneControl : MonoBehaviour {

	GameObject lastCheckpoint;

	void Start(){
		
	}

	void Update(){
	}

	void OnTriggerEnter(Collider coll){
		lastCheckpoint = CheckpointControl.chkDict[CheckpointTracker.chkLast];
		RespawnControl.Respawn (coll.gameObject, lastCheckpoint);	
	}
}
