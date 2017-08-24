using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapDoor : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(){
		GetComponent<CloseTrapDoor> ().Close ();
	}

	void OnTriggerExit(){
		GetComponent<CloseTrapDoor> ().Open ();
	}
}
