using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarEngine : MonoBehaviour {

	Rigidbody rb;
	private float radius = 3F;
    private float power = 20.0F;	
	private float upwardsMod = 0f;
	void Awake(){
	
		rb = GetComponent<Rigidbody>();
	
	}
	void Start () {
		MoveMortar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
 	}

	public void MoveMortar(){
		rb.AddForce(transform.forward * BulletDefs.bullets[BulletType.SHELL].speed, ForceMode.Impulse);
	}

	void OnCollisionEnter(){
		Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
			if(hit.tag == "Enemies" && hit.GetComponent<EnemyHealth>() != null){
 				Rigidbody rb = hit.GetComponent<Rigidbody>();
				hit.GetComponent<EnemyHealth>().DeductHealth(BulletDefs.bullets[BulletType.SHELL].attackDamage);
				if (rb != null)
					// Debug.Log("hit " + rb.name);
					rb.AddExplosionForce(power, explosionPos, radius, upwardsMod, ForceMode.Impulse);
			}
        }

		Destroy(gameObject, 0.01f);
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "Door"){
			Destroy(gameObject);
		}
	}

}
