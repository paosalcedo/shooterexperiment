using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : TargetMovement {

	// Use this for initialization
	// Update is called once per frame
	public override void FixedUpdate(){
		Move(EnemyDefs.enemyDict[EnemyDefs.EnemyType.DRONE].speed);
	}
}
