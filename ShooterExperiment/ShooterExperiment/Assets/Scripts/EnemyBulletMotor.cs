using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMotor : MonoBehaviour {

	private float speed = 20f;
	private GameObject lastCheckpoint;
	// Use this for initialization
	void Start () {
//		Destroy (gameObject, 1f);
		speed = 20f;
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Translate (transform.forward * -speed * Time.deltaTime);
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Player") {	
			lastCheckpoint = CheckpointControl.chkDictP1 [CheckpointControl.chkLastP1];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
 		} 

		if (coll.gameObject.tag == "Player2") {
			lastCheckpoint = CheckpointControl.chkDictP2 [CheckpointControl.chkLastP2];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
 		}
		Destroy (gameObject);
	}
}
