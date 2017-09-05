using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo {

	public WeaponType weapon;
	public GameObject bullet;
	public float grav;
	public float speed;
	public int attackDamage;
	public AudioClip clip;


//	public class PrizeInfo {
//		private static Dictionary<PrizeSlot, PrizeInfo> prizes = new Dictionary<PrizeSlot, PrizeInfo>();
//		public int value;
//		public PrizeSlot slot;
//		public RewardType type;
//		public Sprite rewardImage;
//
//		}

	public BulletInfo(WeaponType weapon_, float grav_, float speed_, int attackDamage_){
		weapon = weapon_; 
		grav = grav_;
		speed = speed_;
		attackDamage = attackDamage_;
	}

}
