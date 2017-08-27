using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpen : MonoBehaviour {

	public MeshRenderer triggerMesh;
	MeshRenderer whiteMesh;
	ParticleSystem particles;

	public GameObject doorToOpen;

	// Use this for initialization
	void Start () {
		whiteMesh = GetComponent<MeshRenderer> ();
		particles = GetComponentInChildren<ParticleSystem> ();
 	}

	void OnTriggerEnter(Collider collider){
		particles.Play ();
		doorToOpen.GetComponent<OpenDoor> ().Open ();
		triggerMesh.enabled = true;
		whiteMesh.enabled = false;

	}

	void OnTriggerExit(Collider collider){
		particles.Stop ();
		doorToOpen.GetComponent<OpenDoor> ().Close ();
		triggerMesh.enabled = false;
		whiteMesh.enabled = true;
	}
		

}
