using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTween : MonoBehaviour {
	
	public float delay;
	// Use this for initialization
	void Start () {
		LeanTween.moveLocalY(this.gameObject, 20, 0.5f).setEaseInSine().setLoopPingPong().setDelay(delay);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision coll)
	{
		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER1) {
			GameObject lastChkpt = CheckpointControl.chkDict [CheckpointControl.chkLast+1];
			Debug.Log("Sending " + PlayerSwitcherScript.currentPlayer + " to " + CheckpointControl.chkLast+1);
			RespawnControl.Respawn (coll.gameObject, lastChkpt);
		} else {
			GameObject lastChkpt = CheckpointControl.chkDict [CheckpointControl.chkLast];
			Debug.Log("Sending " + PlayerSwitcherScript.currentPlayer + " to " + CheckpointControl.chkLast);
			RespawnControl.Respawn (coll.gameObject, lastChkpt);
		}
	}


}
