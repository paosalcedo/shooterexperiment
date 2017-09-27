using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	private float deathDelay = 3f;
	private int health; 
	private Rigidbody rb;

	private bool playerIsDead;
	private bool tweenIsDone;
	// Use this for initialization
	void Start () {
		playerIsDead = false;
		tweenIsDone = false;
		health = PlayerDefs.playerDict[PlayerType.LASER].health;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			GetComponent<FPSController>().enabled = false;
			GetComponentInChildren<MouseLook>().enabled = false;
			rb.freezeRotation = false;
			rb.isKinematic = true;
			if(!tweenIsDone){
				LeanTween.rotate(gameObject, new Vector3(-90f, 0, 0), deathDelay*0.5f).setEaseInSine();				
				LeanTween.moveLocalY(gameObject, 0f, deathDelay*0.5f).setEaseInSine();
				tweenIsDone = true;
			}
			StartCoroutine(KillPlayer(deathDelay));
 		}
	}

	public virtual void TakeDamage(int damage_){
		health -= damage_;
		Debug.Log(gameObject.name + "'s health is " + health);
	} 
	
 	IEnumerator KillPlayer(float delay){
		yield return new WaitForSeconds(delay);
		if(!playerIsDead){
 			// gameObject.SetActive(false);
			playerIsDead = true;
		}
	}
}
