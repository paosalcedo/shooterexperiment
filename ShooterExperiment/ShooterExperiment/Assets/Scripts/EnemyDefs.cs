using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefs { 

//	public static EnemyInfo[] enemyDefs = {
//		new EnemyInfo (
// 			"Basic enemy.", //Description 
//			60, //Health
//			20, //Movement Speed
//			20, //Attack speed
//			1 // attack cooldown in seconds
//		),
//
//		new EnemyInfo (
// 			"First boss", //Description
//			1000, //Health   
//			40, //movement speed
//			60, //Attack speed
//			0.5f //attack cooldown in seconds
//		)
//	};

	public static Dictionary<string, EnemyInfo> enemyDict = new Dictionary<string, EnemyInfo> ();

	public void GenerateEnemyDefs(){
		EnemyDefs.enemyDict.Add ("Drone", 
			new EnemyInfo 
			(
				"Basic enemy.", //Description 
				60, //Health
				20, //Movement Speed
				20, //Attack speed
				1 // attack cooldown in seconds
			)
		);
		EnemyDefs.enemyDict.Add ("Chopper", 
			new EnemyInfo 
			(
				"First boss", 
				40, //Health   
				40, //movement speed
				60, //Attack speed
				0.5f //attack cooldown in seconds
			)
		);
		Debug.Log ("Enemy Defs Generated");
 	}

}
