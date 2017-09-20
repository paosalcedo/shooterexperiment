using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefs { 

	public enum EnemyType
	{
		DRONE,
		CHOPPER,
        TARGET,
        SOLDIER
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

	public static Dictionary<EnemyType, EnemyInfo> enemyDict = new Dictionary<EnemyType, EnemyInfo>();

//	Dictionary<string, EnemyInfo> testdict = new Dictionary<string, EnemyInfo>(){ 
//		new KeyValuePair<string, EnemyInfo>("test1", new EnemyInfo("Lol", 60, 60 ,0 ,0)),
//		new KeyValuePair<string, EnemyInfo>("test2", new EnemyInfo("haha", 20, 20, 20, 20))
//	};

	public void GenerateEnemyDefs(){
		EnemyDefs.enemyDict.Add (EnemyType.DRONE, 
			new EnemyInfo 
			(
				"Basic enemy.", //Description 
				60, //Health
				20, //Movement Speed
				20, //Attack speed
				1, // attack cooldown in seconds
                "Enemy"
			)
		);

		EnemyDefs.enemyDict.Add (EnemyType.CHOPPER, 
			new EnemyInfo 
			(
				"First boss", 
				1000, //Health   
				10, //movement speed
				100, //Attack speed
				0.5f, //attack cooldown in seconds
			    "Boss"
            )
		);

        EnemyDefs.enemyDict.Add(EnemyType.TARGET,
            new EnemyInfo
            (
                "Target Practice",
                500, //HP
                15, //movement speed
                0, //attack speed
                0, //attack cooldown in seconds
                "Target"
            )       
        );

        EnemyDefs.enemyDict.Add(EnemyType.SOLDIER,
            new EnemyInfo(
                 "Lowly conscript",
                100, //HP
                20, //movement speed
                0, //attack speed
                0, //attack cooldown in seconds
                "Soldier"
            )
        );
		Debug.Log ("Enemy Defs Generated");
  	}

}
