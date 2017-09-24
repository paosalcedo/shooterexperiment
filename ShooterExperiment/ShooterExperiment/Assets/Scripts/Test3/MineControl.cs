using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineControl : GunControl {

	private Vector3 modPos = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Attack(attackKey, modPos);
	}

	public override void Attack(KeyCode key, Vector3 setModPos){
		if(Input.GetKeyDown(key)){
			GameObject bullet;
			GetComponentInParent<ActionRecorder>().isAttacking = true;
			bullet = Instantiate (Resources.Load ("Prefabs/Weapons/Mine")) as GameObject;
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
 		}
  	}

}
