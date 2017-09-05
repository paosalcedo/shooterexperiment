using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBasic : MonoBehaviour {

	protected string gunName = "StickyGun";
	protected string bulletName = "Ball";

	private WeaponType ballType;
	private float ballGrav;
	private float ballSpeed;
	private float stuckCounter = 3f;
	private int attackDamage;
	bool stuck = false;

	private Rigidbody rb;

	void Start(){
		ballType = BulletDefs.bulletDefs [0].weapon;
		ballGrav = BulletDefs.bulletDefs [0].grav;
		ballSpeed = BulletDefs.bulletDefs [0].speed;
		rb = GetComponent<Rigidbody> ();
		Destroy (gameObject, 5);
	}

	void Update(){
//		if (stuck) {
//			stuckCounter -= Time.deltaTime;
//			if (stuckCounter <= 0f)
//				ballSpeed = 0f;
//		}
	}

	void FixedUpdate(){
		rb.velocity = transform.forward * ballSpeed;
//		rb.AddForce(transform.forward * ballSpeed, ForceMode.Impulse);
//		rb.AddForce (new Vector3 (0, -ballGrav * rb.mass, 0));
//		rb.AddForce(Vector3.down * ballGrav * rb.mass, ForceMode.Force);

	}

	void OnCollisionEnter(Collision coll){
//		if (coll.gameObject.tag != "Player") {
// 			stuck = true;
//		}
		attackDamage = BulletDefs.bulletDefs[0].attackDamage;
		if (coll.gameObject.GetComponent<EnemyHealth> () != null) {
			Debug.Log("HIT ENEMY");
			coll.gameObject.GetComponent<EnemyHealth> ().DeductHealth (attackDamage);
		}
		Destroy (gameObject);
//		StartCoroutine(DelayedDeath(0.01f));
	}

	IEnumerator DelayedDeath(float delay){
		yield return new WaitForSeconds (delay);
		Destroy (gameObject);
	}
}
