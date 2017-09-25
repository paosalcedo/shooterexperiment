using System.Collections;
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
        if(enemyToSpawn == "Hulk"){
            enemy.transform.position = enemy.transform.position + (Vector3.up * 10f);
        }
        Debug.Log(enemyToSpawn + " spawned at " + enemy.transform.position);
    }

    public virtual int RandomEnemyNum()
    {
        return Random.Range(0, 3);
    }

    public virtual float RandomSpawnCountdown() {
        // return Random.Range(5, 11);
        return Random.Range(5, 11);
    }

    public int RandomSpawnpointNum() {
        return Random.Range(0, 9);
    }

    Vector3 RandomizedSpawnpoint() {
        return enemySpawnpoints[RandomSpawnpointNum()].transform.position; //add randomness here
    }

    Vector3 RandomVec3(){
        Vector3 randomVec3;
        randomVec3 = new Vector3 (Random.Range(-10,10),0, 0);
        return randomVec3; 
    }

    void EnemyRespawnCountdown() {
        seconds -= Time.deltaTime;
        if (seconds <= 0) {
             switch (RandomEnemyNum())
            {
                case 0:
                    enemyToSpawn = "Soldier";
                    break;
                case 1:
                    enemyToSpawn = "Target";
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
