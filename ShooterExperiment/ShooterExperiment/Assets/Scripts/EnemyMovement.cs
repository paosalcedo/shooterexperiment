using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class EnemyMovement : MonoBehaviour {
	//we want to set up basic movement first.
//	Rigidbody rb;
	float speed = 1f;
	float attackSpeed = 20f;
	public float aggressiveRange = 10f;
	public GameObject player;
	Rigidbody rb;

	Vector3 playerDir;

	public enum EnemyState{
		NORMAL,
		ALERTED
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
			rb.AddForce(playerDir * attackSpeed * Time.deltaTime);
		} 
		DetectPlayer ();
	}

	//reverse direction upon collision with wall
	void OnCollisionEnter (Collision coll)
	{
		if (enemyState != EnemyState.ALERTED) {
			speed *= -1f;
		}
	}

	float risk (){
		return Random.Range (0,100);
	}

	//check how close the player is
	public void DetectPlayer(){
		float distanceToPlayer;
		distanceToPlayer = Vector3.Distance (player.transform.position, transform.position);
		if (distanceToPlayer <= aggressiveRange) {
 			enemyState = EnemyState.ALERTED;
		}

	

	}
}
