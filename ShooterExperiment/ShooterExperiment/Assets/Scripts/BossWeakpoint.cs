using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakpoint : MonoBehaviour {

	private int health;
	private int maxHealth;
	private int damage;
	private GameObject lastCheckpoint;
	
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
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			StartCoroutine (LoadWinScreen (5f));
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.name == "Player") {	
			lastCheckpoint = CheckpointControl.chkDictP1 [CheckpointControl.chkLastP1];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
		} 

		if (coll.gameObject.name == "Player2") {
			lastCheckpoint = CheckpointControl.chkDictP2 [CheckpointControl.chkLastP2];
			RespawnControl.Respawn (coll.gameObject, lastCheckpoint);
		} 
	}

	IEnumerator LoadWinScreen(float delay){
		yield return new WaitForSeconds (delay);
		Debug.Log ("LOL YOU WON!");
		SceneControl.LevelComplete ();
	}
}
