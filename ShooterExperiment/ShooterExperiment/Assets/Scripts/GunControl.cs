using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	// Use this for initialization
	public KeyCode attackKey;
	Vector3 modPos;
	public float modPosX;
	public float modPosY;
	public float modPosZ;

	void Start () {
		modPos = new Vector3 (modPosX, modPosY, modPosZ);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER1) {
			Attack (attackKey, modPos);		
		}
	}

	public void Attack(KeyCode key, Vector3 setModPos){
		if(Input.GetKeyDown (key)){
			GameObject bullet = Instantiate (Resources.Load ("Prefabs/Weapons/BlueBullet")) as GameObject;
			bullet.transform.position = transform.position + setModPos;
			bullet.transform.rotation = transform.rotation;
			Debug.Log ("PLAYER 1 FIRES BALL!");
		}
	}
		

}
