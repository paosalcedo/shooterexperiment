using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

	public GameObject levelHolder;
	public enum Activator
	{
		ACTIVATE,
		DEACTIVATE,
		BOTH
	};

	public Activator activator;

	public int level;
 
	void OnTriggerExit(Collider coll){
 
		if (activator == Activator.ACTIVATE) {
			levelHolder.GetComponent<LevelLoader> ().levels [level].SetActive (true);
			
		} 

		if (activator == Activator.DEACTIVATE) {
			if (LevelLoader.P1_hasProgressed && LevelLoader.P2_hasProgressed) {
				levelHolder.GetComponent<LevelLoader> ().levels [level].SetActive (false);
			}
		} 

		if (activator == Activator.BOTH) {
			levelHolder.GetComponent<LevelLoader> ().levels [level].SetActive (true);
			levelHolder.GetComponent<LevelLoader> ().levels [level].SetActive (false);
		}
	}
}
