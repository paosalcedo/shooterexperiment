using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateJumpPad : MonoBehaviour {

	public GameObject triggerToActivate;
	public GameObject particles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(){
		
		triggerToActivate.GetComponent<JumpPadTrigger> ().ActivateJumpPad ();
		particles.SetActive (true);
		StartCoroutine (DelayedInactive (0.10f));
	}

	IEnumerator DelayedInactive (float delay){
		yield return new WaitForSeconds (delay);
		particles.SetActive (false); 
	}
}
