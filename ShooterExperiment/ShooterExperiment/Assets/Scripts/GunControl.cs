using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER1) {
			
		}
	}

	public void Attack(KeyCode key){
		if(Input.GetKeyDown (key)){
			GameObject bullet = Instantiate (Resources.Load ("Prefabs/Weapons/BlueBullet")) as GameObject;
		}
	}

	public void GetBulletDef(){
			
	}

}
