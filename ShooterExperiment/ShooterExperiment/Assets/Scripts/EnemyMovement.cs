using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class EnemyMovement : MonoBehaviour {
	//we want to set up basic movement first.
//	Rigidbody rb;
	float speed = 1f;
	public GameObject player;
	public TextMesh riskText;

	public enum EnemyState{
		NORMAL,
		ALERTED
	}

	EnemyState enemyState;

	// Use this for initialization
	void Start () {
//		rb = GetComponent<Rigidbody> ();
		enemyState = EnemyState.NORMAL;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("Risk is: " + risk ());
//		rb.AddForce (transform.right * speed * Time.deltaTime);
		if (enemyState == EnemyState.NORMAL) {
			transform.position += transform.forward * speed * Time.deltaTime;
			riskText.text = risk ().ToString();
		}
		DetectPlayer ();
	}

	//reverse direction upon collision with wall
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Wall") {
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
		if (distanceToPlayer <= 5f) {
			if (risk () <= 10f) {
				enemyState = EnemyState.ALERTED;
				Debug.Log (enemyState);
			} else {
				Debug.Log ("You're good");
			}
		}

		if (enemyState == EnemyState.ALERTED) {
			Vector3 playerDir = player.transform.position - transform.position;
			transform.position += playerDir * speed * Time.deltaTime;
		} 

	}
}
