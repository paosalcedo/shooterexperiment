using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadTrigger : MonoBehaviour {

	public GameObject jumpPad;
	private float jumpPadForce = 50f;

	public enum JumpPadState {
		ON,
 		OFF
	}

	void Start(){
		jumppadState = JumpPadState.OFF;
	}

	JumpPadState jumppadState;

	void OnTriggerStay(Collider coll){

		if (coll.gameObject.tag == "Player"
			&& jumppadState == JumpPadState.ON) {
			coll.gameObject.GetComponent<FPSController> ().enabled = true;
			coll.gameObject.GetComponent<FPSController> ().SuperJump (jumpPadForce);
//			coll.gameObject.GetComponent<FPSController> ().enabled = true;

			//			jumpPad.GetComponent<JumpPad> ().ActivateJumpPad ();
		}
 	}

	public void ActivateJumpPad(){
		Debug.Log ("Activating jump pad!");
		jumppadState = JumpPadState.ON;
		StartCoroutine(DeactivateJumpPad(0.5f));
	}

	IEnumerator DeactivateJumpPad(float delay){
		yield return new WaitForSeconds (delay);
		jumppadState = JumpPadState.OFF;
	}
}
