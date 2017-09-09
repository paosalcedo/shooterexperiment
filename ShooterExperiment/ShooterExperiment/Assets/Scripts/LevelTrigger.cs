using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

	public GameObject levelHolder;
	public enum Activator
	{
		ACTIVATE,
		DEACTIVATE,
		BOTH,
		NEITHER
	};

	public Activator activator;

	public int level;
 
	void OnTriggerExit (Collider coll)
	{
 
		if (coll.gameObject.GetComponent<FPSController> () != null) {
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
		
			if (activator == Activator.NEITHER) {
				return;
			}
		}
	}
}
