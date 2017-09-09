using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointTrackerP2 : MonoBehaviour {

	public int chkKey;
	public GameObject checkpointNotice;
	private bool alreadyBeenReached;

	// Use this for initialization
	void Start () {
		alreadyBeenReached = false;
 		CheckpointControl.chkDictP2.Add (chkKey, this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter (Collider coll)
	{
		//this is now the new checkpoint.
		//Destroy the first one.		
 
		if (coll.gameObject.tag == "Player2") {
//			Destroy (CheckpointControl.chkDict [CheckpointControl.chkLast]);
			CheckpointControl.chkLastP2 = chkKey;
			if (!alreadyBeenReached) {
				checkpointNotice.SetActive (true);
				StartCoroutine(HideText (3f));
				alreadyBeenReached = true;
			}
		} 
	}

	void OnTriggerExit (Collider coll)
	{
		//this is now the new checkpoint.
		//Destroy the first one.		

		if (coll.gameObject.tag == "Player2") {
			//			Destroy (CheckpointControl.chkDict [CheckpointControl.chkLast]);
			CheckpointControl.chkLastP2 = chkKey; 
		} 
	}

	IEnumerator HideText (float delay){
		yield return new WaitForSeconds(delay);
		checkpointNotice.SetActive(false);
	}
}
