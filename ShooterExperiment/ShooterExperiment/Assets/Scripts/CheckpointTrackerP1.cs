using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointTrackerP1 : MonoBehaviour {

	public int chkKey; 
	public GameObject checkpointNotice;

	private bool alreadyBeenReached;

	// Use this for initialization
	void Start () {
		alreadyBeenReached = false;
		CheckpointControl.chkDictP1.Add (chkKey, this.gameObject);	
	}

	void OnTriggerEnter (Collider coll)
	{

		if (coll.gameObject.GetComponent<FPSController> () != null) {
			if (coll.gameObject.tag == "Player") {
				CheckpointControl.chkLastP1 = chkKey;
				if (!alreadyBeenReached) {
					checkpointNotice.SetActive (true);
					StartCoroutine (HideText (3f));
					alreadyBeenReached = true;
				}
			}
		}
	}

	IEnumerator HideText (float delay){
		yield return new WaitForSeconds(delay);
		checkpointNotice.SetActive(false);	
	}
}
