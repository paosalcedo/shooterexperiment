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

	public static void Open(){
 		doorMesh.enabled = false;
		doorColl.enabled = false;
	}

	public static void Close(){
 		doorMesh.enabled = true;
		doorColl.enabled = true;
	}

	

	
}
