using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndofLevelProgress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player"){
			LevelLoader.P1_hasProgressed_1 = true;
		}

		if (coll.gameObject.tag == "Player2") {
			LevelLoader.P2_hasProgressed_1 = true;
		}
	}
}
