using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topple : MonoBehaviour {
	Rigidbody rb; 
	public TextMesh riskText;
	public GameObject player;

	public enum BuildingState
	{
		NORMAL,
		DESTRUCTIVE
	}


	BuildingState buildingState;

	// Use this for initialization
	void Start () {
		buildingState = BuildingState.NORMAL;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
 		riskText.text = risk ().ToString ();
		DetectPlayer ();
	}

	float risk (){
		return Random.Range (0f, 100f);	 
	}

	public void DetectPlayer(){
		float distanceToPlayer;
		distanceToPlayer = Vector3.Distance (player.transform.position, transform.position);
		if (distanceToPlayer <= 20f) {
			if (risk () <= 10f) {
				buildingState = BuildingState.DESTRUCTIVE;
				Debug.Log (buildingState);
			} else {
				Debug.Log ("You're good");
			}
		}

		if (buildingState == BuildingState.DESTRUCTIVE) {
			rb.AddRelativeTorque(Vector3.right * 100f);		
		} 

	}
}
