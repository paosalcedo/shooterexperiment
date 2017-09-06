using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadTrigger : MonoBehaviour {

	public GameObject jumpPad;
	public GameObject fakePad;
	private float jumpPadForce = 20f;

	public enum JumpPadColor{
		RED,
		BLUE
	}

	public JumpPadColor jumppadColor;

	public enum JumpPadState {
		ON,
 		OFF
	}

	void Start(){
		jumppadState = JumpPadState.OFF;
	}

	JumpPadState jumppadState;

	void OnTriggerStay(Collider coll){
		switch (jumppadColor)
		{
		case JumpPadColor.RED:
			if (coll.gameObject.tag == "Player"
			    && jumppadState == JumpPadState.ON) {
				coll.gameObject.GetComponent<FPSController> ().enabled = true;
				coll.gameObject.GetComponent<FPSController> ().SuperJump (jumpPadForce);				coll.gameObject.GetComponent<FPSController> ().enabled = true;
				coll.gameObject.GetComponent<FPSController> ().enabled = false;
			}
			break;
		case JumpPadColor.BLUE:
			if (coll.gameObject.tag == "Player2"
			    && jumppadState == JumpPadState.ON) {
				coll.gameObject.GetComponent<FPSController> ().enabled = true;
				coll.gameObject.GetComponent<FPSController> ().SuperJump (jumpPadForce);
				coll.gameObject.GetComponent<FPSController> ().enabled = false;
			}
			break;
		default: 
			break;
		}
 	}

	public void ActivateJumpPad(){
		Debug.Log ("Activating jump pad!");
		jumppadState = JumpPadState.ON;
		LeanTween.move (fakePad, Vector3.up * 10f, 1.5f).setEaseInSine ().setLoopOnce();
		StartCoroutine(DeactivateJumpPad(0.5f));
	}

	IEnumerator DeactivateJumpPad(float delay){
		yield return new WaitForSeconds (delay);
		jumppadState = JumpPadState.OFF;
	}
}
