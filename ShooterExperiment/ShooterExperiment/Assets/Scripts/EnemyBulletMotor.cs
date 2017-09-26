using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMotor : MonoBehaviour {

 	// private GameObject lastCheckpoint;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
//		Destroy (gameObject, 1f);
 		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Translate (transform.forward * -speed * Time.deltaTime);
//		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void FixedUpdate(){
		rb.velocity = transform.forward * EnemyDefs.enemyDict[EnemyDefs.EnemyType.DRONE].attackSpeed;
	}


	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.tag == "Player"){
			//DAMAGE PLAYER
			Destroy(gameObject);
		} else{
			Destroy(gameObject);
		}
	}

	//OLD
	// void OnCollisionEnter(Collision coll){
	// 	if (coll.gameObject.tag == "Player") {	
	// 		lastCheckpoint = CheckpointControl.chkDictP1 [CheckpointControl.chkLastP1];
	// 		RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
	// 		Debug.Log ("Player1 checkpoint is " + CheckpointControl.chkLastP1);
 	// 	} 

	// 	if (coll.gameObject.tag == "Player2") {
	// 		lastCheckpoint = CheckpointControl.chkDictP2 [CheckpointControl.chkLastP2];
	// 		RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
	// 		Debug.Log ("Player2 checkpoint is " + CheckpointControl.chkLastP2);
 	// 	}
	// 	Destroy (gameObject);
	// }
}
