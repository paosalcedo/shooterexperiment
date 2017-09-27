using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	private int health; 

	// Use this for initialization
	void Start () {
		health = PlayerDefs.playerDict[PlayerType.LASER].health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void TakeDamage(int damage_){
		health -= damage_;
		Debug.Log(gameObject.name + "'s health is " + health);
	}
}
