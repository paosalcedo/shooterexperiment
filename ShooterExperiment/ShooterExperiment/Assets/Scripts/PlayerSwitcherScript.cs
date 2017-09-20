using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherScript : MonoBehaviour {


    public GameObject leftPlayer;
    public GameObject midPlayer;
    public GameObject rightPlayer;
    public GameObject godPlayer;

    private GameObject presentPlayer;

	public GameObject player1;
	public GameObject player2;
	public GameObject mainCamera;
	GameObject currentCam;
	public KeyCode oldSwitchKey;

	private Quaternion p1_lastRot;
	private Quaternion p2_lastRot;

	public static GameObject currentParent;

	public enum CurrentPlayer{
		PLAYER1,
		PLAYER2
	}

	public static CurrentPlayer currentPlayer;
	// Use this for initialization
	void Start () {
        presentPlayer = godPlayer;
		//currentPlayer = CurrentPlayer.PLAYER1;
		//currentParent = player1;
//		currentCam = Camera.main.transform.gameObject;
 	}
	
	// Update is called once per frame
	void Update () {
		SwitchPlayer (oldSwitchKey);	
	}

    public virtual void SelectMidPlayer(KeyCode key) {
        presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
        presentPlayer.GetComponent<FPSController>().enabled = false;
        presentPlayer.GetComponentInChildren<Camera>().enabled = false;
        presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
        presentPlayer.GetComponentInChildren<GunControl>().enabled = false;

        midPlayer.GetComponentInChildren<MouseLook>().enabled = true;
        midPlayer.GetComponent<FPSController>().enabled = true;
        midPlayer.GetComponentInChildren<Camera>().enabled = true;
        midPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
        midPlayer.GetComponentInChildren<GunControl>().enabled = true;

        presentPlayer = midPlayer;
    }

    public virtual void SelectGodPlayer(KeyCode key) {
        presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
        presentPlayer.GetComponent<FPSController>().enabled = false;
        presentPlayer.GetComponentInChildren<Camera>().enabled = false;
        presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
        presentPlayer.GetComponentInChildren<GunControl>().enabled = false;

        godPlayer.GetComponentInChildren<MouseLook>().enabled = true;
        godPlayer.GetComponent<FPSController>().enabled = true;
        godPlayer.GetComponentInChildren<Camera>().enabled = true;
        godPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
        godPlayer.GetComponentInChildren<GunControl>().enabled = true;

        presentPlayer = godPlayer;

    }

    public void SwitchPlayer(KeyCode key){
		if (Input.GetKeyDown(key)) {
			if (currentPlayer == CurrentPlayer.PLAYER1) {
				Debug.Log("Current Player is " + currentPlayer);

//				mainCamera.transform.SetParent (player2.transform);
//				mainCamera.transform.position = player2.transform.position;
//				mainCamera.transform.localPosition = new Vector3 (0f, 1f, 0f);
				player1.GetComponentInChildren<MouseLook>().enabled = false;
  				player1.GetComponent<FPSController> ().enabled = false;
				player1.GetComponentInChildren<Camera> ().enabled = false;
				player1.GetComponentInChildren<Rigidbody> ().useGravity = true;
				player1.GetComponentInChildren<GunControl>().enabled = false;

				player2.GetComponentInChildren<MouseLook> ().enabled = true;
				player2.GetComponent<FPSController> ().enabled = true;
				player2.GetComponentInChildren<Camera> ().enabled = true;
				player2.GetComponentInChildren<Rigidbody> ().useGravity = false;
				player2.GetComponentInChildren<GunControl>().enabled = true;
 				currentPlayer = CurrentPlayer.PLAYER2;
 				currentParent = player2;
				
				return;
			}

			if (currentPlayer == CurrentPlayer.PLAYER2) {
				Debug.Log("Current Player is " + currentPlayer);

//				mainCamera.transform.SetParent (player1.transform);
//				mainCamera.transform.position = player1.transform.position;
//				mainCamera.transform.localPosition = new Vector3 (0f, 1f, 0f);
				player2.GetComponentInChildren<MouseLook> ().enabled = false;
 				player2.GetComponent<FPSController> ().enabled = false;
				player2.GetComponentInChildren<Camera> ().enabled = false;
				player2.GetComponentInChildren<Rigidbody> ().useGravity = true;
				player2.GetComponentInChildren<GunControl>().enabled = false;
 
				player1.GetComponentInChildren<MouseLook>().enabled = true;
				player1.GetComponent<FPSController> ().enabled = true;
				player1.GetComponentInChildren<Camera> ().enabled = true;
				player1.GetComponentInChildren<Rigidbody> ().useGravity = false;
				player1.GetComponentInChildren<GunControl>().enabled = true;
 				currentPlayer = CurrentPlayer.PLAYER1;
				currentParent = player1;
 				return;
			}
		}
	}
}
