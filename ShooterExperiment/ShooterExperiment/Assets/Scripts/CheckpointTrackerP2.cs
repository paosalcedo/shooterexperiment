using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrackerP2 : MonoBehaviour {

	public int chkKey;
	// Use this for initialization
	void Start () {
 		CheckpointControl.chkDictP2.Add (chkKey, this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider coll)
	{
		//this is now the new checkpoint.
		//Destroy the first one.		
 
		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER2) {
//			Destroy (CheckpointControl.chkDict [CheckpointControl.chkLast]);
			CheckpointControl.chkLastP2 = chkKey; 
		} 
	}

	void OnTriggerExit (Collider coll)
	{
		//this is now the new checkpoint.
		//Destroy the first one.		

		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER2) {
			//			Destroy (CheckpointControl.chkDict [CheckpointControl.chkLast]);
			CheckpointControl.chkLastP2 = chkKey; 
		} 
	}

}
