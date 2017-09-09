using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier1GateOpener : MonoBehaviour {

	public GameObject gate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			if (LevelLoader.P1_hasProgressed_0 && LevelLoader.P2_hasProgressed_0) {
			gate.SetActive (false);
		}
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.tag == "Player") {
			LevelLoader.P1_hasProgressed_0 = true;
		} 
	
		if (coll.gameObject.tag == "Player2") {
			LevelLoader.P2_hasProgressed_0 = true;
		}
	}

}
