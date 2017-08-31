using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class EnemyMovement : MonoBehaviour {
	//we want to set up basic movement first.
//	Rigidbody rb;
	private GameObject lastCheckpoint;

	float speed = 10f;
	float attackSpeed = 20000f;
	public float aggressiveRange = 10f;
	public GameObject player;
	Rigidbody rb;

	Vector3 playerDir;

	public enum EnemyState{
		NORMAL,
		ALERTED,
	}

	EnemyState enemyState;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
//		rb = GetComponent<Rigidbody> ();
		enemyState = EnemyState.NORMAL;

	}
	
	// Update is called once per frame
	void Update () {
		playerDir = player.transform.position - transform.position;

//		Debug.Log ("Risk is: " + risk ());
//		rb.AddForce (transform.right * speed * Time.deltaTime);
		if (enemyState == EnemyState.NORMAL) {
			transform.position += transform.forward * speed * Time.deltaTime;
//			riskText.text = risk ().ToString();
		}
		if (enemyState == EnemyState.ALERTED) {
// 			transform.Translate(playerDir * attackSpeed * Time.deltaTime);
			GameObject enemyBullet = Instantiate(Resources.Load("Prefabs/Weapons/RedBullet")) as GameObject;
			enemyBullet.transform.position = transform.position + Vector3.forward;
			enemyBullet.GetComponent<Rigidbody> ().AddForce (playerDir * attackSpeed * Time.deltaTime);
//			rb.AddForce(playerDir * attackSpeed * Time.deltaTime);
		} 
		DetectPlayer ();
	}

	//reverse direction upon collision with wall
	//kills player.
	void OnCollisionEnter(Collision coll){
		if (enemyState != EnemyState.ALERTED) {
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

	float risk (){
		return Random.Range (0,100);
	}

	//check how close the player is
	public void DetectPlayer(){
//		float distanceToPlayer;
//		distanceToPlayer = Vector3.Distance (player.transform.position, transform.position);
//		if (distanceToPlayer <= aggressiveRange) {
// 			enemyState = EnemyState.ALERTED;
//		}

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
		
}
