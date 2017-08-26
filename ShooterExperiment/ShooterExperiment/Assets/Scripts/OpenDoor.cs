﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public MeshRenderer doorMesh;
	public Collider doorColl;
	public GameObject door;
	Vector3 openRot;
	Vector3 closedRot;

	// Use this for initialization
	void Start () {
//		doorState = DoorState.CLOSED;
		doorMesh = GetComponent<MeshRenderer> ();
		doorColl = GetComponent<Collider> ();
		openRot = new Vector3 (0, 90, 0);
		closedRot = new Vector3(0, -90, 0);
 	}
	
	// Update is called once per frame
	void Update ()
	{		
	}

	public void Open(){
		LeanTween.rotate(door, openRot, 1f).setEaseInSine();
 	}

	public void Close(){
 		 LeanTween.rotate(door, closedRot, 1f).setEaseInSine();
	}

	

	
}
