using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineEngine : MonoBehaviour {

	Rigidbody rb;
	Collider coll;
	public enum MineMode {
		THROWN,
		LANDED,
		TRIPPED
	}

	MineMode mineMode;

	private float mineLandingDelay = 0.5f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		coll = GetComponent<Collider>();
		mineMode = MineMode.THROWN;
		DropMine();
	}
	
	// Update is called once per frame
	void Update () {
		if(mineMode == MineMode.LANDED){
			coll.isTrigger = true;
			rb.isKinematic = true;
		} 

		if(mineMode == MineMode.TRIPPED){
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
		transform.rotation = Quaternion.Euler(Vector3.down);
	}

	void OnCollisionEnter(){
		if(mineMode == MineMode.THROWN){
			mineMode = MineMode.LANDED;
 		} 
	}

	void OnTriggerEnter(Collider coll_){
		if(coll_.gameObject.tag == "Enemies"){
			if(mineMode == MineMode.LANDED){
				coll_.gameObject.GetComponent<EnemyHealth>().DeductHealth(BulletDefs.bullets[BulletType.MINE].attackDamage);
				mineMode = MineMode.TRIPPED;
			} 
		}
	}

	public void DropMine(){
		rb.AddForce(transform.forward * BulletDefs.bullets[BulletType.MINE].speed, ForceMode.Impulse);
	}
}
