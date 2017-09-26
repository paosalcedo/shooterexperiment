using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttackControl : MonoBehaviour {

	private float cooldown;
	private float rotationSpeed = 3f;

	public GameObject[] players;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	private Vector3 playerDir; //direction from this transform to the player.
	private Transform playerTransform;

	private Vector3 startingPos;
	private Quaternion startingRot;

	public LayerMask ownAmmo;

 	public enum AlertState{
		NORMAL,
		ALERTED,
		PLAYER_NEAR
	}

	public AlertState alertState;
	// Use this for initialization

	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		player1 = players[0];
		player2 = players[1];
		player3 = players[2];

		startingPos = transform.position;
		startingRot = transform.rotation;
		cooldown = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].attackCooldown;
	}
	
	// Update is called once per frame
	void Update () {

		playerDir = player1.transform.position - transform.position;
		switch(alertState)	
		{

			case AlertState.NORMAL:
				CheckIfInLineOfSight();
				transform.rotation = Quaternion.Slerp (transform.rotation, startingRot, rotationSpeed * Time.deltaTime);
				break;
			
			case AlertState.PLAYER_NEAR:
				CheckIfInConeOfVision();

				break;
			
			case AlertState.ALERTED:
 				CheckIfInLineOfSight();
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(playerDir), rotationSpeed * Time.deltaTime);
				if (cooldown <= 0f) {
					Fire ();
					cooldown = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].attackCooldown;
				}
				cooldown -= Time.deltaTime;
				break;

			default:
				break;
		}


  

 		// DetectNearestPlayer();
		// CheckIfInLineOfSight();
	
  	}
	void Fire(){
		GameObject enemyBullet = Instantiate(Resources.Load("Prefabs/Weapons/EnemyBullet")) as GameObject;
		enemyBullet.transform.position = transform.position;
		enemyBullet.transform.rotation = transform.rotation;	
	}

	public void DetectNearestPlayer(){
 		 
		  for (int i = 0; i<players.Length; i++){
			  Debug.Log("Distance to " + players[i].name + " " + Vector3.Distance(players[i].transform.position, transform.position));
			  float distToPlayers = Vector3.Distance(players[i].transform.position, transform.position);
			  
			  if(distToPlayers < 10f){
				  //finds the closest player? 					
 				playerTransform = players[i].transform;
				// playerDir = playerTransform.position - transform.position;
				// if(Vector3.Dot(transform.forward, playerTransform.position) > 0){
				// 	alertState = AlertState.ALERTED;
				// } else {
				// 	alertState = AlertState.NORMAL;
				// }			
			  }
		  }

		// RaycastHit hit;
		// Vector3 rayDirection = transform.forward;
		// if (Physics.Raycast (transform.position, rayDirection, out hit)) {
		// 	Debug.Log(hit.transform.name);
		// 	if (hit.transform.tag == "Player") {
 		// 		playerTransform = hit.transform;
		// 		playerDir = playerTransform.position - transform.position;
 		// 	} 
		// }
	}

	//Changes alert state
	public void CheckIfInConeOfVision(){
		Debug.Log("checking if in cone of vision!");
		if(Vector3.Dot(transform.forward, playerDir) > 0.75f){
			alertState = AlertState.ALERTED;
		} 
	}
	
	//FIRST, CHECK IF IN LINE OF SIGHT
	public void CheckIfInLineOfSight(){
		RaycastHit hit;
		Vector3 rayDirection = player1.transform.position - transform.position;
		if (Physics.Raycast (transform.position, rayDirection, out hit, Mathf.Infinity, ownAmmo)) {
			Debug.Log(hit.transform.name);
			if(alertState == AlertState.NORMAL){
				if (hit.transform.name == "Laser") {
					alertState = AlertState.PLAYER_NEAR;
				} else {
					alertState = AlertState.NORMAL;
				}
			}

			if(alertState == AlertState.ALERTED){
				if (hit.transform.name == "Laser") {
					alertState = AlertState.ALERTED;
				} else {
					alertState = AlertState.NORMAL;
				}
			}
		}
	}
}
