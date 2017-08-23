using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public enum DoorState{
		OPEN,
		CLOSED
	}

	MeshRenderer doorMesh;
	Collider doorCollider;

	DoorState doorState;
	// Use this for initialization
	void Start () {
		doorState = DoorState.CLOSED;		
		MeshRenderer doorMesh = GetComponent<MeshRenderer>();
		Collider doorCollider = GetComponent<Collider>();
		
 	}
	
	// Update is called once per frame
	void Update ()
	{		
	}

	public void Open(){	
		doorMesh.enabled = false;
		doorCollider.enabled = false;
	}

	public void Close(){
 		doorMesh.enabled = true;
		doorCollider.enabled = true;
	}

	

	
}
