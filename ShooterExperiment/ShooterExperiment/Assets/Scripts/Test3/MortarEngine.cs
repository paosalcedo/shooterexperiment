using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarEngine : MonoBehaviour {

	Rigidbody rb;
	
	void Awake(){
		rb = GetComponent<Rigidbody>();
	}
	void Start () {
		MoveMortar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
 	}

	public void MoveMortar(){
		rb.AddForce(transform.forward * BulletDefs.bullets[BulletType.SHELL].speed, ForceMode.Impulse);
	}

}
