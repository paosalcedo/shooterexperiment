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
				5, //Health
				15, //Movement Speed
				20, //Attack speed
				50, //attack damage
				1,
                "Enemy"
			)
		);

		EnemyDefs.enemyDict.Add (EnemyType.CHOPPER, 
			new EnemyInfo 
			(
				"First boss", 
				1000, //Health   
				3, //movement speed
				100, //Attack speed
				500, //attack damage
			    1,
				"Boss"
            )
		);

        EnemyDefs.enemyDict.Add(EnemyType.TARGET,
            new EnemyInfo
            (
                "Target Practice",
                100, //HP
                10, //movement speed
                0, //attack speed
                100, //attack damage
                2,
				"Target"
            )       
        );

        EnemyDefs.enemyDict.Add(EnemyType.SOLDIER,
            new EnemyInfo(
                 "Lowly conscript",
                100, //HP
                5, //movement speed
                0, //attack speed
                20, //attack damage
                0,
				"Soldier"
            )
        );
		Debug.Log ("Enemy Defs Generated");
  	}

}
