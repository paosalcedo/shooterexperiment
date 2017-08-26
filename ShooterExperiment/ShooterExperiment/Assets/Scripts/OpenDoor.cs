using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public static MeshRenderer doorMesh;
	public static Collider doorColl;

	// Use this for initialization
	void Start () {
//		doorState = DoorState.CLOSED;
		doorMesh = GetComponent<MeshRenderer> ();
		doorColl = GetComponent<Collider> ();
 	}
	
	// Update is called once per frame
	void Update ()
	{		
	}

	public void Open(){
 		doorMesh.enabled = false;
		doorColl.enabled = false;
	}

	public void Close(){
 		doorMesh.enabled = true;
		doorColl.enabled = true;
	}

	

	
}
