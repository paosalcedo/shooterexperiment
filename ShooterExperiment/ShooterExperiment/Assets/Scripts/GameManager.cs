using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public KeyCode quitKey;

	void Awake(){
		InitializeServices ();
	}
	// Use this for initialization
	void Start () {
 	}
	
	// Update is called once per frame
	void Update () {
        SceneControl.QuitGame(quitKey);
	}

	void InitializeServices(){
 		Services.EnemyDefs = new EnemyDefs ();
		Services.BulletDefs = new BulletDefs();
		Services.PlayerDefs = new PlayerDefs();
		Services.PlayerDefs.GeneratePlayerDefs();
		Services.EnemyDefs.GenerateEnemyDefs ();
		Services.BulletDefs.GenerateBulletDefs();
		Services.Prefabs = Resources.Load<PrefabsDB>("Prefabs/Effects");
 	}
}
