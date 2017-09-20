﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private string enemyToSpawn;
    public GameObject[] enemySpawnpoints;
    private float seconds;

    void Start() {
    }

    void Update() {
        EnemyRespawnCountdown();
     }


    void Spawn(string enemyToSpawn_) {
        GameObject enemy = Instantiate(Resources.Load("Prefabs/Enemies/" + enemyToSpawn)) as GameObject;
        enemy.transform.position = RandomizedSpawnpoint();
        Debug.Log(enemyToSpawn + " spawned");
    }

    public virtual int RandomEnemyNum()
    {
        return Random.Range(0, 3);
    }

    public virtual float RandomSpawnCountdown() {
        return Random.Range(5, 11);
    }

    public int RandomSpawnpointNum() {
        return Random.Range(0, 3);
    }

    Vector3 RandomizedSpawnpoint() {
        return enemySpawnpoints[RandomSpawnpointNum()].transform.position;
    }

    void EnemyRespawnCountdown() {
        seconds -= Time.deltaTime;
        if (seconds <= 0) {
             switch (RandomEnemyNum())
            {
                case 0:
                    enemyToSpawn = "Target";
                    break;
                case 1:
                    enemyToSpawn = "Soldier";
                    break;
                case 2:
                    enemyToSpawn = "Hulk";
                    break;
                default:
                    break;
            }
            Spawn(enemyToSpawn);
            seconds = RandomSpawnCountdown();
         }
    }
}