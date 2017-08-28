using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnControl : MonoBehaviour {
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void Respawn(GameObject _playerThatDied, GameObject _lastCheckpoint){
		_playerThatDied.transform.position = _lastCheckpoint.transform.position;
 	}
}
