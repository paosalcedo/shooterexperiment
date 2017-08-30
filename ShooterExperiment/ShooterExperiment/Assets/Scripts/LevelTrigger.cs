using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

	public GameObject levelHolder;

	void OnTriggerEnter(Collider coll){
		levelHolder.GetComponent<LevelLoader> ().levels [0].SetActive (false);
	}
}
