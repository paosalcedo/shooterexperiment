using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : TargetMovement {

	public override void Start () {
		base.Start();
 		// LeanTween.move(gameObject, leftLimit, 5f).setLoopPingPong();

	}
	
	// Update is called once per frame
	

	public override void FixedUpdate(){
		targetDir = destination.transform.position - transform.position;

		Move(EnemyDefs.enemyDict[EnemyDefs.EnemyType.CHOPPER].speed);		
	}
	
}
