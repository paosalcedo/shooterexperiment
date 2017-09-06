using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefs { 

	public enum EnemyType
	{
		DRONE,
		CHOPPER
	}

	EnemyType enemyType;
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

	public static Dictionary<EnemyType, EnemyInfo> enemyDict = new Dictionary<EnemyType, EnemyInfo> ();

//	Dictionary<string, int> testdict = new Dictionary<string, EnemyInfo>(){
//		new KeyValuePair<string, EnemyInfo>("test1", new EnemyInfo(),
//		new KeyValuePair<string,int>("test2",2)
//	};

	public void GenerateEnemyDefs(){
		EnemyDefs.enemyDict.Add (EnemyType.DRONE, 
			new EnemyInfo 
			(
				"Basic enemy.", //Description 
				60, //Health
				20, //Movement Speed
				20, //Attack speed
				1 // attack cooldown in seconds
			)
		);
		EnemyDefs.enemyDict.Add (EnemyType.CHOPPER, 
			new EnemyInfo 
			(
				"First boss", 
				500, //Health   
				20, //movement speed
				100, //Attack speed
				0.5f //attack cooldown in seconds
			)
		);
		Debug.Log ("Enemy Defs Generated");
  	}

}
