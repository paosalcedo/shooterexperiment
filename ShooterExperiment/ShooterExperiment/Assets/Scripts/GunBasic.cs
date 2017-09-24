using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBasic : MonoBehaviour {

	protected string gunName = "StickyGun";
	protected string bulletName = "Ball";

	private BulletType ballType;
	private float ballGrav;
	private float ballSpeed;
 	private int attackDamage;
 
	private Rigidbody rb;
	private MeshRenderer mesh;

	void Start(){
 		ballGrav = BulletDefs.bullets [BulletType.BALL].grav;
		ballSpeed = BulletDefs.bullets [BulletType.BALL].speed;
		rb = GetComponent<Rigidbody> ();
		mesh = GetComponent<MeshRenderer>();
    	mesh.enabled = false;
 		StartCoroutine(EnableMesh(0.05f));
		Destroy (gameObject, 5);
	}

	void Update(){

	}

	void FixedUpdate(){
		rb.velocity = transform.forward * ballSpeed;
	}

	void OnCollisionEnter(Collision coll){
 
		attackDamage = BulletDefs.bullets[BulletType.BALL].attackDamage;
		if (coll.gameObject.tag == "Enemies") {
			if (coll.gameObject.GetComponent <EnemyHealth> () != null) {
				coll.gameObject.GetComponent<EnemyHealth> ().DeductHealth (attackDamage);
			} else if (coll.gameObject.GetComponent<BossWeakpoint> () != null) {
				Debug.Log ("Boss hit!");
				coll.gameObject.GetComponent<BossWeakpoint> ().DeductHealth (attackDamage);
			}
			Destroy (gameObject);
		} else if (coll.gameObject.GetComponent<TriggerTrapDoor>() != null){
			StartCoroutine (DelayedDeath (0.5f));
		}
		else {
			Destroy (gameObject);
		}
 	}

	IEnumerator DelayedDeath(float delay){
		yield return new WaitForSeconds (delay);
		Destroy (gameObject);
	}

	IEnumerator EnableMesh(float delay){
		yield return new WaitForSeconds(delay);
		mesh.enabled = true;
 	}


}
