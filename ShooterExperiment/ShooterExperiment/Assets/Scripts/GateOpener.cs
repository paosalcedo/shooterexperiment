using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour {

	public GameObject gate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelLoader.P1_hasProgressed && LevelLoader.P2_hasProgressed) {
			gate.SetActive (false);			
		}
	}


}
