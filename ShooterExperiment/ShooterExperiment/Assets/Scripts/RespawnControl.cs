using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnControl : MonoBehaviour {
 
	public static void Respawn(GameObject _playerThatDied, GameObject _lastCheckpoint){
		_playerThatDied.transform.position = _lastCheckpoint.transform.position;
 	}

}
