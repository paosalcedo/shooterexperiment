using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

	public GameObject godCanvas;

	public Text numHitText;
 	private float deathDelay = 3f;
	public int health; 

	private int numHits;

	private Rigidbody rb;

	public bool playerIsDead;
	private bool tweenIsDone;

	private ActionRecorder actionRecorder;

	public enum PlayerState{

	}
	
	void Start () {
		playerIsDead = false;
		tweenIsDone = false;
		health = PlayerDefs.playerDict[PlayerType.LASER].health;
		rb = GetComponent<Rigidbody>();
		numHits = 0;
		actionRecorder = GetComponent<ActionRecorder>();
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
			} 
		}

		//	Put this code back in if you want the player to only take damage in LIVE.
		//**************************************************************************** 
		// if(GameStateControl.gameState == GameStateControl.GameState.LIVE){
		// 	if(health <= 0){
		// 		if(!playerIsDead){ //if player is alive
		// 			GetComponent<FPSController>().enabled = false;
		// 			GetComponentInChildren<MouseLook>().enabled = false;
		// 			// GetComponent<ActionRecorder>().StopPlayback();
		// 			rb.freezeRotation = false;
		// 			rb.isKinematic = true;
		// 			if(!tweenIsDone){
		// 				LeanTween.rotate(gameObject, new Vector3(-90f, 0, 0), deathDelay*0.5f).setEaseInSine();				
		// 				LeanTween.moveLocalY(gameObject, 0f, deathDelay*0.5f).setEaseInSine();
		// 				tweenIsDone = true;
		// 			} 
		// 			playerIsDead = true;
 		// 		} 
 		// 	}
		// }
		//************************************************************************************

		//check if game is in SIMULATION state and if currently selected player is RECORDING.
		if (GameStateControl.gameState == GameStateControl.GameState.SIMULATION 
			&& actionRecorder.recordingState == ActionRecorder.RecordingState.RECORDING){
			//update the num hit value
			numHitText.text = "You've taken " + numHits.ToString() + "/3 hits.";
			if(numHits >= 3){
				//do something
			}
		}
	}

	public virtual void TakeDamage(int damage_){
		//only take damage
		health -= damage_;
		//	Put this code back in if you want the player to only take damage in LIVE.

		// if(GameStateControl.gameState == GameStateControl.GameState.LIVE){
		// 	health -= damage_;
 		// } 

		// if(GameStateControl.gameState == GameStateControl.GameState.SIMULATION){
		// 	numHits++;
 		// }
	} 
	
}
