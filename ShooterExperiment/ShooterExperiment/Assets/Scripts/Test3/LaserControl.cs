using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : GunControl {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack(KeyCode key, Vector3 setModPos)
    {
        if (Input.GetKeyDown(key)) {

        }
    }
}
