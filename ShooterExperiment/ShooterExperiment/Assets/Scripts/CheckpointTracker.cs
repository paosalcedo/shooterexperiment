using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour {

	public GameObject gate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelLoader.P1_hasProgressed_1 && LevelLoader.P2_hasProgressed_1) {
			gate.SetActive (false);
		}
	}
}
