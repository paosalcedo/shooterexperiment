 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttackControl : MonoBehaviour {

	private float cooldown;
	private float rotationSpeed = 3f;

	public GameObject[] players;

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
		PLAYER_NEAR
	}

	public AlertState alertState;
	// Use this for initialization

	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");

		startingPos = transform.position;
		startingRot = transform.rotation;
		cooldown = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].attackCooldown;
	}
	
	// Update is called once per frame
	void Update () {
 
		DetectNearestPlayer();
		CheckIfInLineOfSight();
		playerDir = closestPlayer.transform.position - transform.position;

		switch(alertState)	
		{

			case AlertState.NORMAL:

				//return to normal pos and rot
				transform.rotation = Quaternion.Slerp (transform.rotation, startingRot, rotationSpeed * Time.deltaTime);
				// transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(playerDir), rotationSpeed * Time.deltaTime);

				break;
			
			case AlertState.PLAYER_NEAR:
 				break;
			
			case AlertState.ALERTED:
  
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

  	}
	void Fire(){
		GameObject enemyBullet = Instantiate(Resources.Load("Prefabs/Weapons/EnemyBullet")) as GameObject;
		enemyBullet.transform.position = transform.position;
		enemyBullet.transform.rotation = transform.rotation;	
	}

	public void DetectNearestPlayer(){
 		for (int i = 0; i < players.Length; i++) {
			distToPlayer[i] = Vector3.Distance(players[i].transform.position, transform.position);
            for (int j = i+1; j < players.Length; j++) {
                if ( (distToPlayer[i] > distToPlayer[j]) && (i != j) ) {
					GameObject tempGameObject;
					tempGameObject = players[j];
					players[j] = players[i];
					players[i] = tempGameObject;
                }
            }
        }

		closestPlayer = players[0];
		// if(closestVisiblePlayer != players[0]){
		// 	for(int i = 0; i<players.Length; i++){

		// 	}
		// }
		
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
	public void CheckIfInConeOfVision(){
 		if(Vector3.Dot(transform.forward, playerDir) > 0.75f){
			alertState = AlertState.ALERTED;
		} 
	}
	
	//FIRST, CHECK IF IN LINE OF SIGHT

	private Vector3 rayDirection;
	public void CheckIfInLineOfSight(){
		RaycastHit hit;
 		rayDirection = closestPlayer.transform.position - transform.position;
 		Debug.DrawRay(transform.position, rayDirection * 5f, Color.red);
		if (Physics.Raycast (transform.position, rayDirection, out hit, Mathf.Infinity, ownAmmo)) {
			Debug.Log("Raycast hit " + hit.transform.name);
 			if(alertState == AlertState.NORMAL){
				//ORIGINAL, WORKING
				// if (hit.transform.tag == "Player") {
				// 	alertState = AlertState.ALERTED;
				// } else {
				// 	alertState = AlertState.NORMAL;
				// }	

				if (hit.transform.tag == "Player") {
 					// if(hit.transform != closestPlayer.transform){
					// 	closestPlayer = closestVisiblePlayer;
					// } 
					alertState = AlertState.ALERTED;
				} else {
					alertState = AlertState.NORMAL;
				}
			}

			if(alertState == AlertState.ALERTED){
				if (hit.transform.tag == "Player") {
					alertState = AlertState.ALERTED;
				} else {
					alertState = AlertState.NORMAL;
				}
			}
		}
	}
}
