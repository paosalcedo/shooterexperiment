using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillControl : MonoBehaviour {

	public GameObject crusher1;
	public GameObject crusher2;
	public GameObject crusher3;

	public GameObject triggerOff;
	public GameObject triggerOn;

	private GameObject player;
	Rigidbody rb;
	bool paused;
  
 	void Start () {
		paused = false;
 	}
		
 
//	void OnTriggerEnter(Collider coll){
//		if (coll.gameObject.GetComponent<FPSController> () != null) {
//			player = coll.gameObject;
//			rb = player.GetComponent<Rigidbody> ();
//		}
// 	}

	void OnTriggerStay (Collider coll)
	{
		Rigidbody rb_;

		if (coll.gameObject.GetComponent<FPSController> () != null) {
			rb_ = coll.gameObject.GetComponent<Rigidbody> ();
			if (rb_ != null) {
				if (rb_.velocity.magnitude > 2.5f) {
					if (!paused) {
						SendPause ();
						triggerOn.SetActive (true);
						triggerOff.SetActive (false);		
						paused = true;
					}
				} else {
					if (paused) {
						SendResume ();			
						triggerOn.SetActive (false);
						triggerOff.SetActive (true);	
						paused = false;
					}
				}
			}
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.gameObject.GetComponent<FPSController> () != null) {
			if (paused) {
				SendResume ();			
				triggerOn.SetActive (false);
				triggerOff.SetActive (true);	
				paused = false;
			}
		}	
	}

	void OnTriggerExit(){
		rb = null;
		triggerOn.SetActive (false);
		triggerOff.SetActive (true);	
		SendResume ();
	}

	void SendPause(){
  		crusher1.SendMessage ("PauseTween");
		crusher2.SendMessage ("PauseTween");
		crusher3.SendMessage ("PauseTween");
 	}

	void SendResume(){
  		crusher1.SendMessage ("ResumeTween");
		crusher2.SendMessage ("ResumeTween");
		crusher3.SendMessage ("ResumeTween");
	}



}
