using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTrapDoor : MonoBehaviour {

	public GameObject trapDoor1;
	public GameObject trapDoor2;
	private Vector3 newRot;
	private Vector3 oldRot;

 
	// Use this for initialization
	void Start () {
		newRot = new Vector3 (0, 0, 0);
		oldRot = new Vector3(-90f, 0f, 0f); 
 	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Operate(){
		LeanTween.rotate (trapDoor1, newRot, 1f).setEaseInSine (); 
		LeanTween.rotate (trapDoor2, -newRot, 1f).setEaseInSine ();

//		LeanTween.rotate(trapDoor1, Vector3.right, 1f).setEaseInSine().setOnComplete(
//			()=>{
//				LeanTween.rotate(trapDoor1, newRot, 1f).setEaseInSine().setDelay(2f); 
//			}
//		);
//		LeanTween.rotate(trapDoor2, Vector3.right, 1f).setEaseInSine().setOnComplete(
//			()=>{
//				LeanTween.rotate(trapDoor2, -newRot, 1f).setEaseInSine().setDelay(2f);
//			}
//		);  
 //		trapDoor1.transform.rotation = Quaternion.AngleAxis (0, Vector3.right);
//		trapDoor2.transform.rotation = Quaternion.AngleAxis (0, Vector3.left);
	}

	public void Open(){
		LeanTween.rotate (trapDoor1, oldRot, 2f).setEaseInSine ();
		LeanTween.rotate (trapDoor2, -oldRot, 2f).setEaseInSine ();
	}

}
