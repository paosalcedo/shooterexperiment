using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth {

	public TextMesh healthText;
	// private int health;
	// Use this for initialization
	public override void Start () {
		health = EnemyDefs.enemyDict[EnemyDefs.EnemyType.CHOPPER].health;		
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = health.ToString();
	}

	public override void DeductHealth(int damage_){
		base.DeductHealth(damage_);
	}


}
