using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakpoint : MonoBehaviour {

	private int health;
	private int maxHealth;
	private int damage;
	
	// Use this for initialization
	void Start () {
		health = EnemyDefs.enemyDict[EnemyDefs.EnemyType.CHOPPER].health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DeductHealth (int damage_)
	{
		damage = damage_;
		health -= damage;
		Debug.Log ("Boss health: " + health + "/" + EnemyDefs.enemyDict [EnemyDefs.EnemyType.CHOPPER].health);
		if (health <= 0) {
			Destroy(gameObject);
		}
	}	
}
