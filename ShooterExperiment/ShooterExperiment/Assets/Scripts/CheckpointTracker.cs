using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour {

	public int chkKey;
	public static int chkLast;
	// Use this for initialization
	void Start () {
		CheckpointControl.checkpoints.Add (this.gameObject);
		CheckpointControl.chkDict.Add (chkKey, this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		//this is now the new checkpoint.
		//Destroy the first one.		
		Debug.Log("Checkpoint no. " + chkKey + " activated!");

		if(chkKey != 0){
			chkLast = chkKey; 
			Destroy(CheckpointControl.chkDict[0]);
		}
	}

}
