using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topple : MonoBehaviour {
	Rigidbody rb; 
	public TextMesh riskText;
	public float risk;
	public GameObject player;
	private float riskNum;

	public enum BuildingState
	{
		NORMAL,
		DESTRUCTIVE,
		DONE
	}


	BuildingState buildingState;

	// Use this for initialization
	void Start () {
		buildingState = BuildingState.NORMAL;
		rb = GetComponent<Rigidbody> ();
		SetRisk();
	}
	
	// Update is called once per frame
	void Update () {
		riskText.text = riskNum.ToString ();
		DetectPlayer ();
		SetRisk ();
	}

//	float risk (){
//		if (buildingState == BuildingState.NORMAL) {
//			return Random.Range (0f, 100f);
//		} else if (buildingState == BuildingState.DESTRUCTIVE) {
//			return 101f;
//		} else if (buildingState == BuildingState.DONE) {
//			return 101f;
//		} else {
//			return 101f;
//		}
//	}

	public void DetectPlayer(){
		float distanceToPlayer;
		distanceToPlayer = Vector3.Distance (player.transform.position, transform.position);
		if (distanceToPlayer <= 5f) {
			if (riskNum <= 10f) {
				buildingState = BuildingState.DESTRUCTIVE;
				Debug.Log (buildingState);
			} else {
				Debug.Log ("You're good");
			}
		}

		if (buildingState == BuildingState.DESTRUCTIVE) {
			rb.AddRelativeTorque(Vector3.right * 100000f, ForceMode.Impulse);
			buildingState = BuildingState.DONE;
		} 

	}

	public void SetRisk(/*maybe it can take different values from player, like speed at which they approach you? direction?*/){
		riskNum = Random.Range (0f, 100f);	
	}

}
