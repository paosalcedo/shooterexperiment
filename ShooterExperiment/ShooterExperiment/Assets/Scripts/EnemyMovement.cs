using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class EnemyMovement : MonoBehaviour {
	//we want to set up basic movement first.
//	Rigidbody rb;
	private GameObject lastCheckpoint;

	float speed = 10f;
	float attackSpeed = 100f;
	public float aggressiveRange = 10f;
	public GameObject player;
	bool hasFired;
	Rigidbody rb;
	float cooldown;

	Vector3 targetDir;
	Vector3 playerDir;

	public enum EnemyState{
		NORMAL,
		ALERTED,
	}

	public EnemyState enemyState;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
 		enemyState = EnemyState.NORMAL;

	}
	
 	void Update () {
		playerDir = player.transform.position - transform.position;
		targetDir = playerDir;

		switch (enemyState) {
		case EnemyState.NORMAL:
			transform.position += transform.forward * speed * Time.deltaTime;
			break;
		case EnemyState.ALERTED:
			//face the player
			transform.LookAt (player.transform);
//			StartCoroutine (WaitForEnemyToFacePlayer (0.5f));
			if (cooldown <= 0f) {
 				Fire ();
 				cooldown = 1f;
			}
			Debug.Log (cooldown);
			cooldown -= Time.deltaTime;
			break;
		default: 
			break;
		}
			
		DetectPlayer ();
	}

	//reverse direction upon collision with wall
	//kills player.
	void OnCollisionEnter(Collision coll){
		if (enemyState == EnemyState.NORMAL) {
			speed *= -1f;
		}

		if (coll.gameObject.name == "Player") {	
			lastCheckpoint = CheckpointControl.chkDictP1 [CheckpointControl.chkLastP1];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
		} 

		if (coll.gameObject.name == "Player2") {
			lastCheckpoint = CheckpointControl.chkDictP2 [CheckpointControl.chkLastP2];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
		}
	}
		

	//check how close the player is
	public void DetectPlayer(){
		
		RaycastHit hit;
		Vector3 rayDirection = player.transform.position - transform.position;
		if (Physics.Raycast (transform.position, rayDirection, out hit)) {
			if (hit.transform == player.transform) {
				enemyState = EnemyState.ALERTED;
 			} else {
				enemyState = EnemyState.NORMAL;
			}
		}
	}

	void Fire(){
		GameObject enemyBullet = Instantiate(Resources.Load("Prefabs/Weapons/EnemyBullet")) as GameObject;
		enemyBullet.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);
		enemyBullet.transform.rotation = transform.rotation;	
	}

	IEnumerator WaitForEnemyToFacePlayer (float delay){
		yield return new WaitForSeconds (delay);
//		if (!hasFired && cooldown <= 0f) {
		if (!hasFired){
			Fire ();
//			hasFired = true;
			cooldown = 0.25f;
		}
	}
		
}
