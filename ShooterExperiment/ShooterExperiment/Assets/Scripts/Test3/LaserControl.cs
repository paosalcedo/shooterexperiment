using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : GunControl {

	private int attackDamage;
	public LayerMask playerLayer; 
 	public float laserLifetime = 1f;
	float laserLifetimeReset;

	bool isFiring = false;
 	public Transform laserTarget;
	// Use this for initialization
	void Start () {
		laserLifetimeReset = laserLifetime;
		attackDamage = BulletDefs.bullets[BulletType.LASER].attackDamage;
	}
	
	// Update is called once per frame
	void Update () {
		Attack(attackKey, Vector3.zero);

		//hide the laser after laserLifetime seconds
		 
	}

    public override void Attack(KeyCode key, Vector3 setModPos)
    {
        if (Input.GetKeyDown(key)) {
			// DrawLaser();
			ShootRay();
			ShootRay();
			ShootRay();
			ShootRay();
			ShootRay();
			ShootRay();
			ShootRay();
			ShootRay();
			ShootRay();

        }	 
    }

	public void ShootRay(){
	
		//RNG recoil spread
		Ray ray = new Ray(transform.position, transform.forward + new Vector3 (Random.Range(-0.05f,0.05f), Random.Range(-0.05f,0.05f), 0));
		
		//no spread
		// Ray ray = new Ray(transform.position, transform.forward);

		RaycastHit rayHit = new RaycastHit();

		if(Physics.Raycast (ray, out rayHit, Mathf.Infinity, playerLayer)){
 			if(rayHit.transform.name != "Laser"){
				laserTarget = rayHit.transform;
				GameObject hitEffect; 
				hitEffect = Instantiate(Resources.Load("Prefabs/Effects/LaserHit") as GameObject);
				hitEffect.transform.position = rayHit.point;
  				if(rayHit.transform.tag == "Enemies"){
					rayHit.transform.GetComponent<EnemyHealth>().DeductHealth(attackDamage);
				}
			 }
		}
	}

	public void DrawLaser(){
		GameObject bullet;
		GetComponentInParent<ActionRecorder>().isAttacking = true;
		bullet = Instantiate (Resources.Load ("Prefabs/Weapons/LaserBullet")) as GameObject;
//				Debug.Log (gameObject.name + " is attacking!"); 
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
//				bullet.GetComponent<MeshRenderer>().enabled = false;
  	}
}
