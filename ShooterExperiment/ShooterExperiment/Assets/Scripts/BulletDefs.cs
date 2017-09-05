﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDefs {

	public static BulletInfo[] bulletDefs = {
		new BulletInfo (
			WeaponType.BALL,
/*gravity*/	100,
/*speed*/	80,
/*damage*/	20
		),

		new BulletInfo(
			WeaponType.REFLECTOR,
			0,
			1000,
			0
		),

		new BulletInfo(
			WeaponType.CONE,
			0,
			100f,
			0
		)


	};
		

}
