using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealth : EnemyHealth
{
    public TextMesh healthText;
    public int targetHealth;
     // Use this for initialization
    Rigidbody rb;

    void Awake(){
        GameStateControl.enemies.Add(gameObject);
    }
    public override void Start(){
        rb = GetComponent<Rigidbody>();
        targetHealth = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].health;
        collisionDamage = EnemyDefs.enemyDict[EnemyDefs.EnemyType.TARGET].attackDamage;

    }

    public override void Update() {
        base.Update();
        healthText.text = targetHealth.ToString();

        // if(GameStateControl.gameState == GameStateControl.GameState.SIMULATION){
        //     rb.isKinematic = true;
        // } else {
        //     rb.isKinematic = false;
        // }
    }

    public override void DeductHealth(int damage_)
    {
        Debug.Log(targetHealth);
        damage = damage_;
        targetHealth -= damage;
        if (targetHealth <= 0)
        {
            GameStateControl.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
        // if(GameStateControl.gameState == GameStateControl.GameState.LIVE){
        //     Debug.Log(targetHealth);
        //     damage = damage_;
        //     targetHealth -= damage;
        //     if (targetHealth <= 0)
        //     {
        //         GameStateControl.enemies.Remove(gameObject);
        //         Destroy(gameObject);
        //     }
        // }
    }
}
