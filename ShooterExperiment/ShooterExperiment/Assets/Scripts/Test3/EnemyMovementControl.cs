using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementControl : MonoBehaviour {

	private GameObject destination;

    private Vector3 targetDir;
    Rigidbody rb; 

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        destination = GameObject.Find("EnemyTarget");
        targetDir = destination.transform.position - transform.position;
     }
	
	// Update is called once per frame
	void Update ()
    {
        targetDir = destination.transform.position - transform.position;

        Move(EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].speed);
	}

    public void Move(float speed_) {
        rb.velocity = targetDir * speed_ * Time.deltaTime;
    }
}
