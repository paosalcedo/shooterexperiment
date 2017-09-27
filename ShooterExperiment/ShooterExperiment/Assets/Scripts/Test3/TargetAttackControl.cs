 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttackControl : MonoBehaviour {

	private float cooldown;
	private float rotationSpeed = 3f;

	// public GameObject[] players;

	public List<GameObject> playersInCone = new List<GameObject>();
	public List<GameObject> playersInConeAndInSight = new List<GameObject>();	

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	public GameObject closestPlayer;
	public GameObject closestVisiblePlayer;
	public float[] distToPlayer;

	private Vector3 playerDir; //direction from this transform to the player.
	private Transform closestPlayerTransform;

	private Vector3 startingPos;
	private Quaternion startingRot;

	public LayerMask ownAmmo;

 	public enum AlertState{
		NORMAL,
		ALERTED,
		SCANNING
 	}

	public AlertState alertState;
	// Use this for initialization

	Vector3 player1Dir;
	Vector3 player2Dir;
	Vector3 player3Dir;
	void Start () {
		// players = GameObject.FindGameObjectsWithTag("Player");

		player1Dir = player1.transform.position - transform.position;
		player2Dir = player2.transform.position - transform.position;
		player3Dir = player3.transform.position - transform.position;

		startingPos = transform.position;
		startingRot = transform.rotation;
		cooldown = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].attackCooldown;
		// DetectNearestPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		//update player locations
		player1Dir = player1.transform.position - transform.position;
		player2Dir = player2.transform.position - transform.position;
		player3Dir = player3.transform.position - transform.position;
 
		//only check for players in cone if there are actually players in the cone
		

		switch(alertState)	
		{

			case AlertState.NORMAL:

				CheckLineOfSightForAll();

				if(PlayerIsInConeOfVision()){
					Debug.Log("hey player is in cone of vision!");
				}
				// if(playersInCone.Count <= 0){
				// 	if(PlayerIsInConeOfVision()){
				// 		Debug.Log("player is in cone of vision!");
				// 		CheckLineOfSightForAll();
				// 		// CheckIfInLineOfSight(closestVisiblePlayer);	
				// 	}
				// }
 		
				//return to normal pos and rot
				transform.rotation = Quaternion.Slerp (transform.rotation, startingRot, rotationSpeed * Time.deltaTime);
				// transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(playerDir), rotationSpeed * Time.deltaTime);

				break;

			case AlertState.SCANNING:
				// transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(playerDir), rotationSpeed * Time.deltaTime);
				break;
			
			case AlertState.ALERTED:
				CheckIfInConeOfVision();
				// CheckIfInLineOfSight(closestVisiblePlayer);	
				CheckLineOfSightForAll();
				if(playersInCone.Count > 0){
					DetectNearestPlayer();
					playerDir = closestPlayer.transform.position - transform.position;
					// transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(playerDir), rotationSpeed * Time.deltaTime);
					if (cooldown <= 0f && playersInConeAndInSight.Count > 0) {
						Fire ();
						cooldown = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].attackCooldown;
					} 
					cooldown -= Time.deltaTime;
				}

				break;

			default:
				break;
		}

  	}
	void Fire(){
		GameObject enemyBullet = Instantiate(Resources.Load("Prefabs/Weapons/EnemyBullet")) as GameObject;
		enemyBullet.transform.position = transform.position;
		enemyBullet.transform.rotation = transform.rotation;	
	}

	public void DetectNearestPlayer(){
 		// for (int i = 0; i < players.Length; i++) {
		// 	distToPlayer[i] = Vector3.Distance(players[i].transform.position, transform.position);
        //     for (int j = i+1; j < players.Length; j++) {
        //         if ( (distToPlayer[i] > distToPlayer[j]) && (i != j) ) {
		// 			GameObject tempGameObject;
		// 			tempGameObject = players[j];
		// 			players[j] = players[i];
		// 			players[i] = tempGameObject;
        //         }
        //     }
        // }

		// closestPlayer = players[0];
		// for (int i = 0; i < playersInCone.Count; i++) {
		// 	distToPlayer[i] = Vector3.Distance(playersInCone[i].transform.position, transform.position);
        //     for (int j = i+1; j < playersInCone.Count; j++) {
        //         if ( (distToPlayer[i] > distToPlayer[j]) && (i != j) ) {
		// 			GameObject tempGameObject;
		// 			tempGameObject = playersInCone[j];
		// 			playersInCone[j] = playersInCone[i];
		// 			playersInCone[i] = tempGameObject;
        //         }
        //     }
        // }

		// closestPlayer = playersInCone[0];

		for (int i = 0; i < playersInConeAndInSight.Count; i++) {
			distToPlayer[i] = Vector3.Distance(playersInConeAndInSight[i].transform.position, transform.position);
            for (int j = i+1; j < playersInConeAndInSight.Count; j++) {
                if ( (distToPlayer[i] > distToPlayer[j]) && (i != j) ) {
					GameObject tempGameObject;
					tempGameObject = playersInConeAndInSight[j];
					playersInConeAndInSight[j] = playersInConeAndInSight[i];
					playersInConeAndInSight[i] = tempGameObject;
                }
            }
        }
		if(playersInConeAndInSight.Count > 0){
 			closestPlayer = playersInConeAndInSight[0];
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(playerDir), rotationSpeed * Time.deltaTime);
		} else if (playersInConeAndInSight.Count <= 0){
			alertState = AlertState.NORMAL;
		}
 	}
	

	//   for (int i = 0; i < sorted.length; i++) {
    //         for (int j = i+1; j < sorted.length; j++) {
    //             if ( (sorted[i] > sorted[j]) && (i != j) ) {
    //                 int temp = sorted[j];
    //                 sorted[j] = sorted[i];
    //                 sorted[i] = temp;
    //             }
    //         }
    //     }

	//Changes alert state
	private bool player1inCone = false;
	private bool player2inCone = false;
	private bool player3inCone = false;

	//Since Vector3.Dot checks for players even through walls, this function checks if they've already been added to the playersInCone list.
	public void CheckIfInConeOfVision(){
 		if(Vector3.Dot(transform.forward, player1Dir) > 0f && !player1inCone){
			playersInCone.Add(player1);
			player1inCone = true;
		} 
		
		if(Vector3.Dot(transform.forward, player2Dir) > 0f && !player2inCone)
		{
			playersInCone.Add(player2);
			player2inCone = true;
		}
		
		if(Vector3.Dot(transform.forward, player3Dir) > 0f && !player3inCone)
		{
			playersInCone.Add(player3);
			player3inCone = true;
		}
	}

	public bool PlayerIsInConeOfVision(){
		bool playerIsInConeOfVision = false;
		if(Vector3.Dot(transform.forward, player1Dir) > 0f){
 			closestVisiblePlayer = player1;
			playerIsInConeOfVision = true;
			if(!player1inCone){
				playersInCone.Add(player1);
			}
			player1inCone = true;

		} if(Vector3.Dot(transform.forward, player2Dir) > 0f && !player2inCone)
		{
 			closestVisiblePlayer = player2;
			playerIsInConeOfVision = true;
			if(!player2inCone){
				playersInCone.Add(player2);
			}
			player2inCone = true;
		}
		if(Vector3.Dot(transform.forward, player3Dir) > 0f && !player3inCone)
		{
 			closestVisiblePlayer = player3;
			playerIsInConeOfVision = true;
			if(!player3inCone){
				playersInCone.Add(player3);
			}
			player3inCone = true;
		}
		return playerIsInConeOfVision;
	}
	
	
 	public void CheckIfInLineOfSight(GameObject closestVisiblePlayer_){
		// RaycastHit hit;
 		// rayDirection = closestPlayer.transform.position - transform.position;
 		// Debug.DrawRay(transform.position, rayDirection * 5f, Color.red);
		// if (Physics.Raycast (transform.position, rayDirection, out hit, Mathf.Infinity, ownAmmo)) {
		// 	Debug.Log("Raycast hit " + hit.transform.name);
 		// 	if(alertState == AlertState.NORMAL){
		// 		//ORIGINAL, WORKING
		// 		// if (hit.transform.tag == "Player") {
		// 		// 	alertState = AlertState.ALERTED;
		// 		// } else {
		// 		// 	alertState = AlertState.NORMAL;
		// 		// }	

		// 		if (hit.transform.tag == "Player") {
 		// 			// if(hit.transform != closestPlayer.transform){
		// 			// 	closestPlayer = closestVisiblePlayer;
		// 			// } 
		// 			alertState = AlertState.ALERTED;
		// 		} else {
		// 			alertState = AlertState.NORMAL;
		// 		}
		// 	}

		// 	if(alertState == AlertState.ALERTED){
		// 		if (hit.transform.tag == "Player") {
		// 			alertState = AlertState.ALERTED;
		// 		} else {
		// 			alertState = AlertState.NORMAL;
		// 		}
		// 	}
		// }

		RaycastHit hit;
 		Vector3 rayDirection = closestVisiblePlayer_.transform.position - transform.position;
 		Debug.DrawRay(transform.position, rayDirection * 5f, Color.red);
		if (Physics.Raycast (transform.position, rayDirection, out hit, Mathf.Infinity, ownAmmo)) {
			if(hit.transform.tag == "Player"){
				if(hit.transform)
					if(!playersInConeAndInSight.Contains(hit.transform.gameObject))
						playersInConeAndInSight.Add(hit.transform.gameObject);
						alertState = AlertState.ALERTED;
			}
		}
	}

	private void CheckLineOfSightForAll(){
		RaycastHit hitRight;
 		Vector3 rayRight = player1Dir;
 		Debug.DrawRay(transform.position, rayRight * 5f, Color.blue);
		if (Physics.Raycast (transform.position, rayRight, out hitRight, Mathf.Infinity, ownAmmo)) {
			if(hitRight.transform.tag == "Player"){
				if(hitRight.transform)
					if(!playersInConeAndInSight.Contains(hitRight.transform.gameObject))
						playersInConeAndInSight.Add(hitRight.transform.gameObject);
						alertState = AlertState.ALERTED;
			} else {
				playersInConeAndInSight.Remove(player1);
			}
		}

		RaycastHit hitLeft;
 		Vector3 rayLeft = player2Dir;
 		Debug.DrawRay(transform.position, rayLeft * 5f, Color.green);
		if (Physics.Raycast (transform.position, rayLeft, out hitLeft, Mathf.Infinity, ownAmmo)) {
			if(hitLeft.transform.tag == "Player"){
				if(hitLeft.transform)
					if(!playersInConeAndInSight.Contains(hitLeft.transform.gameObject))
						playersInConeAndInSight.Add(hitLeft.transform.gameObject);
						alertState = AlertState.ALERTED;
			} else if(hitLeft.transform.tag != "Player") {
				playersInConeAndInSight.Remove(player2);
			}
		}

		RaycastHit hitMid;
 		Vector3 rayMid = player3Dir;
 		Debug.DrawRay(transform.position, rayMid * 5f, Color.cyan);
		if (Physics.Raycast (transform.position, rayMid, out hitMid, Mathf.Infinity, ownAmmo)) {
			if(hitMid.transform.tag == "Player"){
				if(!playersInConeAndInSight.Contains(hitMid.transform.gameObject))
					playersInConeAndInSight.Add(hitMid.transform.gameObject);
					alertState = AlertState.ALERTED;
			} 
			else {
				playersInConeAndInSight.Remove(player3);
			}
		}
	}

	public bool PlayerIsInLineOfSight(){
		bool playerIsInLineOfSight = false;
		RaycastHit hit;
 		Vector3 rayDirection = transform.forward;
 		Debug.DrawRay(transform.position, rayDirection * 5f, Color.red);
		if (Physics.Raycast (transform.position, rayDirection, out hit, Mathf.Infinity, ownAmmo)) {
			if(hit.transform.tag == "Player"){
				alertState = AlertState.ALERTED;
				playerIsInLineOfSight = true;	
			}
		}

		return playerIsInLineOfSight;
	}
}
