using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherScript : MonoBehaviour {


    public GameObject leftPlayer;
    public GameObject midPlayer;
    public GameObject rightPlayer;
    public GameObject godPlayer;

    private List<GameObject> players = new List<GameObject>();

    private GameObject presentPlayer;

	public GameObject player1;
	public GameObject player2;
	public GameObject mainCamera;
	GameObject currentCam;

	public KeyCode oldSwitchKey;
    public KeyCode leftPlayerKey;
    public KeyCode rightPlayerKey;
    public KeyCode midPlayerKey;
    public KeyCode godPlayerKey;


	private Quaternion p1_lastRot;
	private Quaternion p2_lastRot;

	public static GameObject currentParent;

	public enum CurrentPlayer{
		PLAYER1,
		PLAYER2,
	}

    public enum PresentPlayer {
        GOD,
        LEFT,
        RIGHT,
        MID
    }

    public static PresentPlayer playerIsNow;

    public PresentPlayer currentlySelectedPlayer;

	public static CurrentPlayer currentPlayer;
    // Use this for initialization

    private void Awake()
    {
        players.Add(midPlayer);
        players.Add(rightPlayer);
        players.Add(leftPlayer);
    }

    void Start () {

        DeactivatePlayerComponents();

        presentPlayer = godPlayer;
        godPlayer.GetComponentInChildren<Camera>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {

        currentlySelectedPlayer = playerIsNow;

        SelectMidPlayer(midPlayerKey);
        SelectLeftPlayer(leftPlayerKey);
        SelectRightPlayer(rightPlayerKey);
        SelectGodPlayer(godPlayerKey);

        if(presentPlayer != godPlayer) {
            godPlayer.GetComponent<GodControl>().godIsSelected = false;
        }

        switch (playerIsNow) {
            case PresentPlayer.GOD:
                 
                break;
            case PresentPlayer.LEFT:
  
                break;
            case PresentPlayer.RIGHT:
  
                break;
            case PresentPlayer.MID:
                break;
            default:
                break;
        }

 	}

    public void SelectMidPlayer(KeyCode key) {
        if (Input.GetKeyDown(key)) {

            presentPlayer.GetComponentInChildren<Camera>().enabled = false;

            if (presentPlayer != godPlayer)
            {
                presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
                presentPlayer.GetComponent<FPSController>().enabled = false;
                presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
                presentPlayer.GetComponentInChildren<GunControl>().enabled = false;
                presentPlayer.GetComponent<ActionRecorder>().enabled = false;
            }

            midPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(true);
            midPlayer.GetComponentInChildren<MouseLook>().enabled = true;
            midPlayer.GetComponent<FPSController>().enabled = true;
            midPlayer.GetComponentInChildren<Camera>().enabled = true;
            midPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
            midPlayer.GetComponentInChildren<GunControl>().enabled = true;
            midPlayer.GetComponent<ActionRecorder>().enabled = true;
            presentPlayer = midPlayer;
            playerIsNow = PresentPlayer.MID;

        }
    }

    public void SelectGodPlayer(KeyCode key) {
        if(Input.GetKeyDown(key))
        { 
            presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
            presentPlayer.GetComponent<FPSController>().enabled = false;
            presentPlayer.GetComponentInChildren<Camera>().enabled = false;
            presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
            presentPlayer.GetComponentInChildren<GunControl>().enabled = false;
            presentPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(false);

            ReactivateActionRecorders();
 
            //godPlayer.GetComponentInChildren<MouseLook>().enabled = true;
            //godPlayer.GetComponent<FPSController>().enabled = true;
            godPlayer.GetComponentInChildren<Camera>().enabled = true;
            godPlayer.GetComponent<GodControl>().godIsSelected = true;
            //godPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
            //godPlayer.GetComponentInChildren<GunControl>().enabled = true;

            presentPlayer = godPlayer;

            playerIsNow = PresentPlayer.GOD;
        }
    }


    public void SelectLeftPlayer(KeyCode key) {
        if (Input.GetKeyDown(key))
        {
            presentPlayer.GetComponentInChildren<Camera>().enabled = false;

            if (presentPlayer != godPlayer)
            {
                presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
                presentPlayer.GetComponent<FPSController>().enabled = false;
                presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
                presentPlayer.GetComponentInChildren<GunControl>().enabled = false;
                presentPlayer.GetComponent<ActionRecorder>().enabled = false;
            }

            leftPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(true);
            leftPlayer.GetComponentInChildren<MouseLook>().enabled = true;
            leftPlayer.GetComponent<FPSController>().enabled = true;
            leftPlayer.GetComponentInChildren<Camera>().enabled = true;
            leftPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
            leftPlayer.GetComponentInChildren<GunControl>().enabled = true;
            leftPlayer.GetComponent<ActionRecorder>().enabled = true;

            presentPlayer = leftPlayer;
            playerIsNow = PresentPlayer.LEFT;
        }
    }

    public void SelectRightPlayer(KeyCode key)
    {
        if (Input.GetKeyDown(key)) { 
            presentPlayer.GetComponentInChildren<Camera>().enabled = false;

            if (presentPlayer != godPlayer)
            {
                presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
                presentPlayer.GetComponent<FPSController>().enabled = false;
                presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
                presentPlayer.GetComponentInChildren<GunControl>().enabled = false;
                presentPlayer.GetComponent<ActionRecorder>().enabled = false;
            }

            rightPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(true);
            rightPlayer.GetComponentInChildren<MouseLook>().enabled = true;
            rightPlayer.GetComponent<FPSController>().enabled = true;
            rightPlayer.GetComponentInChildren<Camera>().enabled = true;
            rightPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
            rightPlayer.GetComponentInChildren<GunControl>().enabled = true;
            rightPlayer.GetComponent<ActionRecorder>().enabled = true;

            presentPlayer = rightPlayer;
            playerIsNow = PresentPlayer.RIGHT;

        }
    }

    void DeactivatePlayerComponents() {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<FPSController>().enabled = false;
            players[i].GetComponent<ActionRecorder>().enabled = false;
            players[i].GetComponentInChildren<MouseLook>().enabled = false;
            players[i].GetComponentInChildren<Camera>().enabled = false;
            players[i].GetComponentInChildren<Rigidbody>().useGravity = true;
            players[i].GetComponentInChildren<GunControl>().enabled = false;

        }
    }

    void ReactivateActionRecorders()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<ActionRecorder>().enabled = true;
        }
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
