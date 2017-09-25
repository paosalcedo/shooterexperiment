using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEngine : MonoBehaviour {

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 0.5f);
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// MoveLaser();
	}

	
	void MoveLaser(){
		rb.velocity = transform.forward * BulletDefs.bullets[BulletType.LASER].speed;
	}

	void OnCollisionEnter(Collision coll){
		Destroy (gameObject);
	}
}
