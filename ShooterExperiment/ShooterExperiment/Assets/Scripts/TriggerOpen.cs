using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpen : MonoBehaviour {

	public MeshRenderer triggerMesh;
	MeshRenderer whiteMesh;
//	ParticleSystem particles;
	public GameObject particles;

	public GameObject doorToOpen;

	// Use this for initialization
	void Start () {
		whiteMesh = GetComponent<MeshRenderer> ();
//		particles = GetComponentInChildren<ParticleSystem> ();
 	}

	void OnTriggerEnter (Collider collider)
	{
//		particles.Play ();

		if (collider.gameObject.GetComponent<FPSController> () != null) {
			particles.SetActive (true);
			doorToOpen.GetComponent<OpenDoor> ().Open ();
			triggerMesh.enabled = true;
			whiteMesh.enabled = false;
		}

	}

	void OnTriggerExit (Collider collider)
	{
//		particles.Stop ();
		if (collider.gameObject.GetComponent<FPSController> () != null) {
			particles.SetActive (false);
			doorToOpen.GetComponent<OpenDoor> ().Close ();
			triggerMesh.enabled = false;
			whiteMesh.enabled = true;
		}
	}
		

}
