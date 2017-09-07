using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapDoor : MonoBehaviour {

	public GameObject particles;
	public float trapDoorDelay = 3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<GunBasic> () != null) {
			GetComponent<CloseTrapDoor> ().Operate ();
			particles.SetActive (true);
			gameObject.GetComponent<Collider>().enabled = false;
			StartCoroutine (DelayParticleDeath(trapDoorDelay));
		}
	}

	IEnumerator DelayParticleDeath(float trapDoorDelay_){
		yield return new WaitForSeconds (trapDoorDelay_);
		particles.SetActive (false);
		gameObject.GetComponent<Collider>().enabled = true;
		GetComponent<CloseTrapDoor> ().Open ();
	}
}
