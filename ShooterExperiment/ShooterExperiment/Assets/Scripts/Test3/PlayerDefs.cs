using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefs : MonoBehaviour {

	// public static Dictionary<EnemyType, EnemyInfo> enemyDict = new Dictionary<EnemyType, EnemyInfo>();
	public static Dictionary<PlayerType, PlayerInfo> playerDict = new Dictionary<PlayerType, PlayerInfo>();

	public void GeneratePlayerDefs(){
		PlayerDefs.playerDict.Add(
			PlayerType.LASER,
			new PlayerInfo(
				"Laser Pistolero", //class name
				"Standard class with laser pistol", //class description
				100 //class health
			)
		);

		PlayerDefs.playerDict.Add(
			PlayerType.MINEMASTER,
			new PlayerInfo(
				"Mine Master", //class name
				"Drops mines", //class description
				100 //class health
			)
		);

		PlayerDefs.playerDict.Add(
		PlayerType.TANK,
			new PlayerInfo(
				"Tank", //class name
				"Launches mortar shells", //class description
				100 //class health
			)
		);
	}
}
