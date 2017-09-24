using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMaker : MonoBehaviour {

  
	private Transform myTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DrawLaser(){
		GameObject bullet;
		GetComponentInParent<ActionRecorder>().isAttacking = true;
		bullet = Instantiate (Resources.Load ("Prefabs/Weapons/LaserBullet")) as GameObject;
//				Debug.Log (gameObject.name + " is attacking!"); 
		bullet.transform.position = transform.position;
		bullet.transform.rotation = Quaternion.identity;
//				bullet.GetComponent<MeshRenderer>().enabled = false;
  	}
 
}
