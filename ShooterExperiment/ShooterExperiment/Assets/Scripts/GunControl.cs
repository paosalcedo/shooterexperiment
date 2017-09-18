using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	// Use this for initialization
	public KeyCode attackKey;
	Vector3 modPos;
	public float modPosX;
	public float modPosY;
	public float modPosZ;

	void Start () {
		modPos = new Vector3 (modPosX, modPosY, modPosZ);
	}
	
	// Update is called once per frame
	void Update () {
		Attack (attackKey, modPos);		

	}

	public virtual void Attack (KeyCode key, Vector3 setModPos)
	{
		if (Input.GetKeyDown(key)) {
			GameObject bullet;
			if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER1) {
                GetComponentInParent<ActionRecorder>().isAttacking = true;
				bullet = Instantiate (Resources.Load ("Prefabs/Weapons/BlueBullet")) as GameObject;
//				Debug.Log (gameObject.name + " is attacking!");
				bullet.transform.position = transform.position + setModPos;
//				bullet.GetComponent<MeshRenderer>().enabled = false;
				bullet.transform.rotation = transform.rotation;
                GetComponentInParent<ActionRecorder>().isAttacking = true;
            }

			else if (PlayerSwitcherScript.currentPlayer == PlayerSwitcherScript.CurrentPlayer.PLAYER2) {
				bullet = Instantiate (Resources.Load ("Prefabs/Weapons/RedBullet")) as GameObject;
//				Debug.Log (gameObject.name + " is attacking!");
				bullet.transform.position = transform.position + setModPos;
				bullet.transform.rotation = transform.rotation;
                //GetComponentInParent<ActionRecorder>().isAttacking = true;
                //GetComponentInParent<ActionRecorder>().isAttacking = false;

            }
        }
	}
		

}
