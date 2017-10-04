using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

	public GameObject godCanvas;
	private float deathDelay = 3f;
	[SerializeField]int health; 
	private Rigidbody rb;

	public bool playerIsDead;
	private bool tweenIsDone;
	// Use this for initialization
	public enum PlayerState{

	}
	
	void Start () {
		playerIsDead = false;
		tweenIsDone = false;
		health = PlayerDefs.playerDict[PlayerType.LASER].health;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			if(!playerIsDead){ //if player is alive
				GetComponent<FPSController>().enabled = false;
				GetComponentInChildren<MouseLook>().enabled = false;
				// GetComponent<ActionRecorder>().StopPlayback();
				rb.freezeRotation = false;
				rb.isKinematic = true;
				if(!tweenIsDone){
					LeanTween.rotate(gameObject, new Vector3(-90f, 0, 0), deathDelay*0.5f).setEaseInSine();				
					LeanTween.moveLocalY(gameObject, 0f, deathDelay*0.5f).setEaseInSine();
					tweenIsDone = true;
				} 
				playerIsDead = true;
				// StartCoroutine(KillPlayer(deathDelay));
			} 
 		}
	}

	public virtual void TakeDamage(int damage_){
		//only take damage if gamestate is LIVE.
		if(GameStateControl.gameState == GameStateControl.GameState.LIVE){
			health -= damage_;
			Debug.Log(gameObject.name + "'s health is " + health);
		}
	} 
	
 	IEnumerator KillPlayer(float delay){
		yield return new WaitForSeconds(delay);
		if(!playerIsDead){
 			// gameObject.SetActive(false);
 			playerIsDead = true;
		}
	}
}
