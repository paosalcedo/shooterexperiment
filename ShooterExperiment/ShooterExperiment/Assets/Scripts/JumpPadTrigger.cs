using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadTrigger : MonoBehaviour {

	public GameObject jumpPad;
	private float jumpPadForce = 35f;

	public enum JumpPadState {
		ON,
 		OFF
	}

	void Start(){
		jumppadState = JumpPadState.OFF;
	}

	JumpPadState jumppadState;

	void OnTriggerEnter(Collider coll){

		if (coll.gameObject.GetComponent<FPSController> () != null
			&& jumppadState == JumpPadState.ON) {
			coll.gameObject.GetComponent<FPSController> ().SuperJump (jumpPadForce);
			//			jumpPad.GetComponent<JumpPad> ().ActivateJumpPad ();
		}
 	}

	public void ActivateJumpPad(){
		jumppadState = JumpPadState.ON;
	}
}
