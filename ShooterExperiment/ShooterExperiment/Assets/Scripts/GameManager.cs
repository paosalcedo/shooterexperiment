using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	void Awake(){
		InitializeServices ();
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitializeServices(){
		Services.EnemyDefs = new EnemyDefs ();
		Services.EnemyDefs.GenerateEnemyDefs ();
	}
}
