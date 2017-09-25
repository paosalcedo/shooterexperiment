using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo {

	public string desc;
	public int health;
	public float speed;
	public float attackSpeed;
	public int attackDamage;
    public string path;

	public EnemyInfo (string desc_, int health_, float speed_, float attackSpeed_, int attackDamage_, string path_){

 		desc = desc_;
		health = health_;
		speed = speed_;
		attackSpeed = attackSpeed_;
		attackDamage = attackDamage_;
        path = path_;
	}

}
