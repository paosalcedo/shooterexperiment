using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDefs {

	public static Dictionary<BulletType, BulletInfo> bullets = new Dictionary<BulletType, BulletInfo>();

	public void GenerateBulletDefs(){
		Debug.Log("Bullet defs generated!");
		bullets.Add(
			BulletType.BALL, 
			new BulletInfo (
				"plasma globule",
	/*gravity*/	100,
	/*speed*/	80,
	/*damage*/	20
			)
		);
		
		bullets.Add(
			BulletType.REFLECTOR,
			new BulletInfo(
				"bounces off the walls at perfect angles",
				0,
				1000,
				0
			)
		);

		bullets.Add(
			BulletType.CONE,	
			new BulletInfo(
				"no idea",
				0,
				100f,
				0
				)
		);
		
		bullets.Add(
			BulletType.LASER,
			new BulletInfo(
				"Bullets at the speed of light",
				0,
				100f,
				20
			)
		);
		bullets.Add(
			BulletType.SHELL,
			new BulletInfo(
				"Shells",
				9.8f,
				1000f,
				40
			)		
		);

		bullets.Add(
			BulletType.MINE,
			new BulletInfo(
				"Mines",
				9.8f,
				1000f,
				100
			)
		);

		bullets.Add(
			BulletType.STAR,
			new BulletInfo(
				"Ninja stars",
				0f,
				80,
				34
			)	
		);
	}
		
}
