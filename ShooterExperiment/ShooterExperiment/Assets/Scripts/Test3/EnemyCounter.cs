using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {

	private int enemyNumAtStart;
	public Text enemyNumText;
	// Use this for initialization
	void Start () {
		enemyNumAtStart = GameStateControl.enemies.Count;
	}

	
	
	// Update is called once per frame
	void Update () {
		enemyNumText.text = "Enemies left: " + GameStateControl.enemies.Count.ToString() + "/" + enemyNumAtStart;
	}
}
