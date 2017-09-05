﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	private int health = 100;
	private int maxHealth;
 	private int damage;
	// Use this for initialization

	void Start () {
		health = EnemyDefs.enemyDict ["Drone"].health;
  	}
	
	// Update is called once per frame
	void Update () {
	}

	public void DeductHealth(int damage_){
		damage = damage_;
		health -= damage;
		Debug.Log ("Enemy health: " + health + "/" + EnemyDefs.enemyDict["Drone"].health);
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

		
}
