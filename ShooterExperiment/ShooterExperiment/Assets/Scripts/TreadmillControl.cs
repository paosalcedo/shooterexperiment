using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillControl : MonoBehaviour {

	public GameObject crusher1;
	public GameObject crusher2;
	public GameObject crusher3;
	private GameObject player;
	Rigidbody rb;
	bool paused;
	bool resumed;

	public enum TriggerState{
		PAUSED,
		PLAYING
	}

	TriggerState triggerState;
  
	// Use this for initialization
	void Start () {
		paused = false;
		resumed = false;
 	}
	
	// Update is called once per frame
	void Update () {

//		if (rb == null) {
// 			return;
//		} else {
//			if (rb.velocity.magnitude > 5) {
//				if (!paused) {
//					SendPause ();
//					paused = true;
//				}
//		} 	else if (rb.velocity.magnitude <= 5) {
//				SendResume ();
//			}
//		}
//		else {
//			if (!resumed) {
//				SendResume ();
//				resumed = true;
//			}
		//		}
		
	}

	void OnTriggerEnter(Collider coll){
		player = coll.gameObject;
		rb = player.GetComponent<Rigidbody> ();
 	}

	void OnTriggerStay(){
//		Debug.Log ("Player's velocity is: " + rb.velocity.magnitude);
		if (rb.velocity.magnitude > 2.5f) {
			if (!paused) {
				SendPause ();
				paused = true;
			}
		} else {
			if (paused) {
				SendResume ();
				paused = false;
			}
		} 
	}

	void OnTriggerExit(){
		rb = null;
		SendResume ();
	}

	void SendPause(){
		Debug.Log ("pause!!!!");
 		crusher1.SendMessage ("PauseTween");
		crusher2.SendMessage ("PauseTween");
		crusher3.SendMessage ("PauseTween");
 	}

	void SendResume(){
		Debug.Log ("resume!!!!");
 		crusher1.SendMessage ("ResumeTween");
		crusher2.SendMessage ("ResumeTween");
		crusher3.SendMessage ("ResumeTween");
	}



}
