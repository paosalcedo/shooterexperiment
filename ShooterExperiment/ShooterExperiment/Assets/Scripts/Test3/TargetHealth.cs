using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealth : EnemyHealth
{

    public TextMesh healthText;
    private int targetHealth;
    private int damage;
    // Use this for initialization

    void Start()
    {
        targetHealth = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].health;
    }

    void Update() {
        healthText.text = targetHealth.ToString();
    }

    public override void DeductHealth(int damage_)
    {
        damage = damage_;
        targetHealth -= damage;
        Debug.Log("Enemy health: " + targetHealth + "/" + EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].health);
        if (targetHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
