using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

	public float speed = 10.0f;
	public float airControl = 0.1f;
	public float gravity = 10.0f;
	public float maxFallVelocity = 20f;
	public float maxVelocityChange = 10.0f;
	public float fallDeathHeight = 20f;
//	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;

	public KeyCode restartKey;
	public KeyCode showHintsKey;
	public KeyCode quitKey;

	public GameObject[] hints;
 //	float initHeight;


	//CONTROLS
//	public KeyCode attackKey;

	public enum PlayerMoveState {
		JUMPING,
		GROUNDED
	}

	PlayerMoveState playerMoveState;

	Rigidbody rb;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody> ();

//		for (int i = 0; i < hints.Length; i++) {
//			hints [i].SetActive (false);
//		}

// 		ORIGINAL RIGIDBODY SETTINGS
		rb.freezeRotation = true;
		rb.useGravity = false;

//		MINE
//		rb.freezeRotation = true;
//		rb.useGravity = true;
		
		
	}

	
	// Update is called once per frame

	void Update(){
		QuitGame(quitKey);

 		Vector3 velocity = rb.velocity;

		if (grounded && Input.GetButtonDown("Jump")) {
			rb.velocity = new Vector3 (velocity.x, CalculateJumpVerticalSpeed (), velocity.z);
		}

		if (Input.GetKeyDown (restartKey)) {
			SceneControl.RestartGame ();
		}

		ShowHints (showHintsKey);
  	}

	void FixedUpdate()
	{
		MovePlayer ();
 	}
		
	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}


	void MovePlayer(){

		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= speed;

		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = rb.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;

		if (grounded) {
			rb.AddForce (velocityChange, ForceMode.VelocityChange);
 		}

		//jump
//		if (grounded && Input.GetButtonDown("Jump")) {
//			rb.velocity = new Vector3 (velocity.x, CalculateJumpVerticalSpeed (), velocity.z);
			// play the jump sound.
//			AudioSource jump;
//			jump = GetComponent<AudioSource>();
//			jump.Play();
//		}

		//tweaking air control when jumping.
		if (!grounded) {
			rb.AddForce (velocityChange * airControl, ForceMode.VelocityChange);
		}

		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3 (0, -gravity * rb.mass, 0));

		//		grounded = false;

	}
		
	void OnCollisionStay (Collision coll) {
		if (coll.collider.tag == "Ground") {
			grounded = true;
		}
	}

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag == "Ground") {
			grounded = false;
		}
	}

	public void SuperJump(float jumpforce){
		Debug.Log ("Super jumping!");
		Vector3 velocity = rb.velocity;
		rb.velocity = new Vector3 (velocity.x, CalculateSuperJumpVerticalSpeed (jumpforce), velocity.z);
	}

	public float CalculateSuperJumpVerticalSpeed (float jumpPadForce) {
		Debug.Log ("super jump calculated)");
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpPadForce * gravity);
	}

	public void ShowHints(KeyCode key){
		if (Input.GetKey (key)) {
			for (int i = 0; i < hints.Length; i++) {
				hints [i].SetActive (true);
			}
		} else {
			for (int i = 0; i < hints.Length; i++) {
				hints [i].SetActive (false);
			}
		}
	}

	public void QuitGame (KeyCode key)
	{
		if (Input.GetKeyDown (key)) {
			Application.Quit();
		}
	}

}
