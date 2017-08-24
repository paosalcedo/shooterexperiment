using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDefs {

	public static BulletInfo[] bulletDefs = {
		new BulletInfo (
			WeaponType.BALL,
			5,
			20
		),

		new BulletInfo(
			WeaponType.REFLECTOR,
			0,
			1000
		),
	};
		

}
