using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

	private int health = 5000;
	public Text healthText;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Base health remaining: " + health);
		healthText.text = "Base health: " + health.ToString();
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.GetComponent<EnemyHealth>() != null){
			health -= coll.gameObject.GetComponent<EnemyHealth>().collisionDamage;
			Destroy(coll.gameObject);  
		}
	}
}
