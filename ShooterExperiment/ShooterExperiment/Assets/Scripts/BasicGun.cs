﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour {

	protected string bulletName = "Ball";

	private WeaponType ballType;
	private float ballGrav;
	private float ballSpeed;

	private Rigidbody rb;

	void Start(){
		ballType = BulletDefs.bulletDefs [0].weapon;
		ballGrav = BulletDefs.bulletDefs [0].grav;
		ballSpeed = BulletDefs.bulletDefs [0].speed;
		Debug.Log (ballType);
		rb = GetComponent<Rigidbody> ();
	}


	void Update(){
		rb.velocity = transform.forward * ballSpeed * Time.deltaTime;
		rb.AddForce (new Vector3 (0, -ballGrav * rb.mass * Time.deltaTime, 0));
	}

}
