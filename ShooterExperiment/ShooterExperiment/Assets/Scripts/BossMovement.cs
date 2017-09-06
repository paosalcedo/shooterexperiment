using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

	Vector3[] points; 
	Vector3 leftLimit;
	Vector3 rightLimit;
	// Use this for initialization
	void Start () {
		leftLimit = transform.position - Vector3.left * 20f;
 		rightLimit = transform.position - Vector3.right * 25f; 		
		LeanTween.move(gameObject, leftLimit, 2f).setLoopPingPong();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
