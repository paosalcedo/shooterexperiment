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
			coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(BulletDefs.bullets[BulletType.STAR].attackDamage);
			Destroy(gameObject);
		} else{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "Door"){
			Destroy(gameObject);
		}
	}

}
