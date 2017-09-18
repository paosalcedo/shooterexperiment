using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealth : EnemyHealth
{

    public TextMesh healthText;
    private int health;
    private int maxHealth;
    private int damage;
    // Use this for initialization

    void Start()
    {
        health = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].health;
    }

    void Update() {
        healthText.text = health.ToString();
    }

    public override void DeductHealth(int damage_)
    {
        damage = damage_;
        health -= damage;
        Debug.Log("Enemy health: " + health + "/" + EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
