using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodHUD : PlayerHUD {

	public GameObject player;
	public Image healthBar;
	// Use this for initialization
	private int currentHealth = 0;
	private int maxHealth;

	void Start () {
		maxHealth = PlayerDefs.playerDict[PlayerType.LASER].health;
		currentHealth = player.GetComponent<PlayerHealth>().health;
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = player.GetComponent<PlayerHealth>().health;
		UpdateBar(currentHealth, maxHealth);
	}

	public override void UpdateBar(float currentValue, float maxValue){		
		healthBar.fillAmount = currentValue/maxValue;
	}


}
