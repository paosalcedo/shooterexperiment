using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapDoor : MonoBehaviour {

	ParticleSystem particles;

	// Use this for initialization
	void Start () {
		particles = GetComponentInChildren<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(){
		particles.Play ();
		GetComponent<CloseTrapDoor> ().Operate ();
	}

	void OnTriggerExit(){
		particles.Stop ();
		GetComponent<CloseTrapDoor> ().Open ();
	}
}
