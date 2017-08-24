using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpen : MonoBehaviour {

	public MeshRenderer triggerMesh;
	MeshRenderer whiteMesh;

	// Use this for initialization
	void Start () {
		whiteMesh = GetComponent<MeshRenderer> ();
 	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnTriggerEnter(Collider collider){
		OpenDoor.Open ();
		triggerMesh.enabled = true;
		whiteMesh.enabled = false;
	}

	void OnTriggerExit(Collider collider){
		OpenDoor.Close ();
		triggerMesh.enabled = false;
		whiteMesh.enabled = true;
	}

}
