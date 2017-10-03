using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	protected int health = 100;
	protected int maxHealth;
 	protected int damage;

	public int collisionDamage;
	// Use this for initialization

	public virtual void Start () {
		health = EnemyDefs.enemyDict [EnemyDefs.EnemyType.DRONE].health;
		collisionDamage = EnemyDefs.enemyDict[EnemyDefs.EnemyType.DRONE].attackDamage;
  	}
	
	// Update is called once per frame
	public virtual void Update () {
 	}

	public virtual void DeductHealth(int damage_){
		if(GameStateControl.gameState == GameStateControl.GameState.LIVE){
			damage = damage_;
			health -= damage;
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}

		
}
