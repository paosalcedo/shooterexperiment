using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo {

 	public GameObject bullet;
	public float grav;
	public float speed;
	public int attackDamage;
	public AudioClip clip;

	public string desc;

//	public class PrizeInfo {
//		private static Dictionary<PrizeSlot, PrizeInfo> prizes = new Dictionary<PrizeSlot, PrizeInfo>();
//		public int value;
//		public PrizeSlot slot;
//		public RewardType type;
//		public Sprite rewardImage;
//
//		}

	public BulletInfo(string desc_, float grav_, float speed_, int attackDamage_){
 		desc = desc_;
		grav = grav_;
		speed = speed_;
		attackDamage = attackDamage_;
	}

}
