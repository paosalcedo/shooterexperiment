using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarControl : GunControl {

	public float cooldown = 0;
	private float startingCooldown;
	Vector3 modPos = Vector3.zero;
	// Use this for initialization
	public enum FiringState{
		FIRING,
		NOT_FIRING
	}
	void Start () {
		startingCooldown = BulletDefs.bullets[BulletType.SHELL].attackCooldown;
		cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Attack(attackKey, modPos);	
	}
	public override void Attack(KeyCode key, Vector3 setModPos){
		cooldown -= Time.deltaTime;
		if(Input.GetKeyDown(key) && cooldown <= 0){
			GameObject bullet;
			GetComponentInParent<ActionRecorder>().isAttacking = true;
			bullet = Instantiate (Resources.Load ("Prefabs/Weapons/MortarBullet")) as GameObject;
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
			cooldown = startingCooldown;
 		}
  	}
}
