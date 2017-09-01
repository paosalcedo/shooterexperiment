using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressCheck : MonoBehaviour {

	void Update(){
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.name == "Player") {
			LevelLoader.P1_hasProgressed = true;
		}

		if (coll.gameObject.name == "Player2") {
			LevelLoader.P2_hasProgressed = true;
		}
	}
}
