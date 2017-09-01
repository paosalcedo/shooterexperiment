using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointControl : MonoBehaviour {

	public List<GameObject> players = new List<GameObject>();

	public enum Player1Spawns
	{
		FIRST,
		RED_DOOR,
		CRUSHERS,
		AFTER_THE_TUNNEL
	}

	public Player1Spawns player1spawns;

	public enum Player2Spawns
	{
		FIRST,
		AFTER_THE_LEAP,
		UP_THE_STAIRS
	}

	public Player2Spawns player2spawns;


	public List<GameObject> p1_spawns = new List<GameObject> ();
	public List<GameObject> p2_spawns = new List<GameObject> ();

 
	public Dictionary<Player1Spawns, GameObject> p1_spawndict = new Dictionary<Player1Spawns, GameObject>();

	public Dictionary<Player2Spawns, GameObject> p2_spawndict = new Dictionary<Player2Spawns, GameObject>();

//	public void SpawnAt(int _player, int _spawn){
//		RespawnControl.Respawn (players[_player], p1_spawns[_spawn]);
// 	}

	void SetupSpawns(){
		p2_spawndict.Add (Player2Spawns.FIRST, p2_spawns [0]);
		p2_spawndict.Add (Player2Spawns.AFTER_THE_LEAP, p2_spawns [1]);
		p2_spawndict.Add (Player2Spawns.UP_THE_STAIRS, p2_spawns [2]);

		p1_spawndict.Add (Player1Spawns.FIRST, p1_spawns [0]);
		p1_spawndict.Add (Player1Spawns.RED_DOOR, p1_spawns [1]);
		p1_spawndict.Add (Player1Spawns.CRUSHERS, p1_spawns [2]);
		p1_spawndict.Add (Player1Spawns.AFTER_THE_TUNNEL, p1_spawns [3]);
	}

	void P1StartingSpawn(Player1Spawns spawn){
		RespawnControl.Respawn (players [0], p1_spawndict [spawn]);
 	}

	void P2StartingSpawn(Player2Spawns spawn){
		RespawnControl.Respawn (players [1], p2_spawndict [spawn]);
	}

	void Start(){
 		SetupSpawns ();
		P1StartingSpawn (player1spawns);
		P2StartingSpawn (player2spawns);
	}



}
