using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public static MeshRenderer mesh;
	public static Collider coll;

	// Use this for initialization
	void Start () {
//		doorState = DoorState.CLOSED;
		mesh = GetComponent<MeshRenderer> ();
		coll = GetComponent<Collider> ();
 	}
	
	// Update is called once per frame
	void Update ()
	{		
	}

	public static void Open(){
		Debug.Log ("Door open!");
		mesh.enabled = false;
		coll.enabled = false;
	}

	public static void Close(){
		Debug.Log ("Door closed!");
		mesh.enabled = true;
		coll.enabled = true;
	}

	

	
}
