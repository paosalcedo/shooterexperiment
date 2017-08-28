using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour {

	public int chkKey;
	// Use this for initialization
	void Start () {
 		CheckpointControl.chkDict.Add (chkKey, this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider coll)
	{
		//this is now the new checkpoint.
		//Destroy the first one.		
		Debug.Log ("Checkpoint no. " + chkKey + " reached!");		

		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER2) {
//			Destroy (CheckpointControl.chkDict [CheckpointControl.chkLast]);
			CheckpointControl.chkLast = chkKey; 
		} 
	}

}
