using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : GunControl {

	[SerializeField]float laserLifetime = 1f;
	float laserLifetimeReset;

	bool isFiring = false;
 	public Transform laserTarget;
	// Use this for initialization
	void Start () {
		laserLifetimeReset = laserLifetime;
	}
	
	// Update is called once per frame
	void Update () {
		Attack(attackKey, Vector3.zero);

		//hide the laser after laserLifetime seconds
		 
	}

    public override void Attack(KeyCode key, Vector3 setModPos)
    {
        if (Input.GetKeyDown(key)) {
			DrawLaser();
			ShootRay();
        }	 
    }

	void ShootRay(){
	
		Ray ray = new Ray(transform.position, transform.forward);

		RaycastHit rayHit = new RaycastHit();

		if(Physics.Raycast (ray, out rayHit, Mathf.Infinity)){
			//render line? 
			Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
			laserTarget = rayHit.transform;
			if(rayHit.transform.tag == "Enemies"){
				var enemy = rayHit.transform;
				Debug.Log("ray sent!");
				enemy.SendMessage("DeductHealth", 20f); 
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
