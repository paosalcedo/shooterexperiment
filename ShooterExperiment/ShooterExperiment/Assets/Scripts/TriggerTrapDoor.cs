using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapDoor : MonoBehaviour {

	public GameObject particles;
	public float trapDoorDelay = 1.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(){
		GetComponent<CloseTrapDoor> ().Operate ();
		particles.SetActive (true);
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.GetComponent<GunBasic> () != null) {
			StartCoroutine (DelayParticleDeath (trapDoorDelay));
		}
	}

	IEnumerator DelayParticleDeath(float trapDoorDelay_){
		yield return new WaitForSeconds (trapDoorDelay_);
		particles.SetActive (false);
		GetComponent<CloseTrapDoor> ().Open ();
	}
}
