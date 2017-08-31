using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressCheck : MonoBehaviour {

	void Update(){
		Debug.Log (LevelLoader.P1_hasProgressed);
		Debug.Log (LevelLoader.P2_hasProgressed);

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
