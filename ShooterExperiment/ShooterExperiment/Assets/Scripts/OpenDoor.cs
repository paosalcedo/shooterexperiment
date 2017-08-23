using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public enum DoorState{
		OPEN,
		CLOSED
	}

	DoorState doorState;
	// Use this for initialization
	void Start () {
		doorState = DoorState.CLOSED;
 	}
	
	// Update is called once per frame
	void Update ()
	{		
	}

	public void Open(){
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;
		this.gameObject.GetComponent<Collider>().enabled = false;
	}

	public void Close(){
		this.gameObject.GetComponent<MeshRenderer>().enabled = true;
		this.gameObject.GetComponent<Collider>().enabled = true;
	}

	

	
}
