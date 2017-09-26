 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttackControl : MonoBehaviour {

	private float cooldown;
	private float rotationSpeed = 3f;

	public GameObject[] players;

	private GameObject closestPlayer;
	public float[] distToPlayer;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
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
	 
		player1 = players[0];
		player2 = players[1];
		player3 = players[2];

		startingPos = transform.position;
		startingRot = transform.rotation;
		cooldown = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].attackCooldown;
	}
	
	// Update is called once per frame
	void Update () {

		// DetectNearestPlayer();
		DetectNearestPlayer();
		playerDir = closestPlayer.transform.position - transform.position;

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

  	}
	void Fire(){
		GameObject enemyBullet = Instantiate(Resources.Load("Prefabs/Weapons/EnemyBullet")) as GameObject;
		enemyBullet.transform.position = transform.position;
		enemyBullet.transform.rotation = transform.rotation;	
	}

	public void DetectNearestPlayer(){
		Debug.Log("Player closest to enemy is: " + closestPlayer);
		for (int i = 0; i < players.Length; i++) {
			distToPlayer[i] = Vector3.Distance(players[i].transform.position, transform.position);
            for (int j = i+1; j < players.Length; j++) {
                if ( (distToPlayer[i] > distToPlayer[j]) && (i != j) ) {
					closestPlayer = players[j];
					players[j] = players[i];
					players[i] = closestPlayer;
                }
            }
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
	public void CheckIfInConeOfVision(){
 		if(Vector3.Dot(transform.forward, playerDir) > 0.75f){
			alertState = AlertState.ALERTED;
		} 
	}
	
	//FIRST, CHECK IF IN LINE OF SIGHT
	public void CheckIfInLineOfSight(){
		RaycastHit hit;
		Vector3 rayDirection = closestPlayer.transform.position - transform.position;
		if (Physics.Raycast (transform.position, rayDirection, out hit, Mathf.Infinity, ownAmmo)) {
 			if(alertState == AlertState.NORMAL){
				if (hit.transform.tag == "Player") {
					alertState = AlertState.PLAYER_NEAR;
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
