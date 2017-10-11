using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherScript : MonoBehaviour {


    public GameObject leftPlayer;
    public GameObject midPlayer;
    public GameObject rightPlayer;
    public GameObject godPlayer;

    public List<GameObject> players = new List<GameObject>();

    private GameObject presentPlayer;
    public static GameObject presentPlayerStatic;
    public static GameObject otherPlayerStatic;
    private GameObject nextPlayer;
  
    public KeyCode leftPlayerKey;
    public KeyCode rightPlayerKey;
    public KeyCode midPlayerKey;
    public KeyCode godPlayerKey;


	private Quaternion p1_lastRot;
	private Quaternion p2_lastRot;

    public enum PresentPlayer {
        GOD,
        LEFT,
        RIGHT,
        MID,
        PAUSED
    }


    public static PresentPlayer playerIsNow;

    public PresentPlayer currentlySelectedPlayer;

     // Use this for initialization

    private void Awake()
    {
        players.Add(midPlayer); //you can use Instatiate here later, as in "players.Add(Instantiate(Resources.Load...) as GameObject);"
        players.Add(rightPlayer);
        players.Add(leftPlayer);
        presentPlayerStatic = presentPlayer;
    }

    void Start () {
        //turn off the components of the non-God players.
        DeactivatePlayerComponents();

        //Start player in God view
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

        
 	}

     public void SelectMidPlayer(KeyCode key) {
        if (Input.GetKeyDown(key)) {
            if(!midPlayer.GetComponent<PlayerHealth>().playerIsDead){
                DeactivatePresentPlayerComponents();

                midPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(true);
                midPlayer.GetComponent<MeshRenderer>().enabled = false;
                midPlayer.GetComponentInChildren<MouseLook>().enabled = true;
                midPlayer.GetComponent<FPSController>().enabled = true;
                midPlayer.GetComponentInChildren<Camera>().enabled = true;
                midPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
                midPlayer.GetComponentInChildren<GunControl>().enabled = true;
                midPlayer.GetComponent<ActionRecorder>().enabled = true;
                
                presentPlayer = midPlayer;
                presentPlayerStatic = presentPlayer;
                playerIsNow = PresentPlayer.MID;
            }
            else {
                Debug.Log("Mid player is dead!");
            }
        }
    }

    public void SelectGodPlayer(KeyCode key) {
        if(Input.GetKeyDown(key))
        { 
            if(presentPlayer != godPlayer){
                presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
                presentPlayer.GetComponent<FPSController>().enabled = false;
                presentPlayer.GetComponentInChildren<Camera>().enabled = false;
                presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
                presentPlayer.GetComponentInChildren<Rigidbody>().isKinematic = true;
                presentPlayer.GetComponentInChildren<GunControl>().enabled = false;
                presentPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(false);
                presentPlayer.GetComponent<MeshRenderer>().enabled = true;


                ReactivateActionRecorders();
    
                //godPlayer.GetComponentInChildren<MouseLook>().enabled = true;
                //godPlayer.GetComponent<FPSController>().enabled = true;
                godPlayer.GetComponentInChildren<Camera>().enabled = true;
                godPlayer.GetComponent<GodControl>().godIsSelected = true;
                //godPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
                //godPlayer.GetComponentInChildren<GunControl>().enabled = true;

                presentPlayer = godPlayer;
                presentPlayerStatic = presentPlayer;
                playerIsNow = PresentPlayer.GOD;
            }
        }
    }


    public void SelectLeftPlayer(KeyCode key) {
        if (Input.GetKeyDown(key)){
            if(!leftPlayer.GetComponent<PlayerHealth>().playerIsDead){ //first check if player you want to switch to is still alive
                DeactivatePresentPlayerComponents();

                leftPlayer.GetComponent<MeshRenderer>().enabled = false;
                leftPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(true);
                leftPlayer.GetComponentInChildren<MouseLook>().enabled = true;
                leftPlayer.GetComponent<FPSController>().enabled = true;
                leftPlayer.GetComponentInChildren<Camera>().enabled = true;
                leftPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
                leftPlayer.GetComponentInChildren<GunControl>().enabled = true;
                leftPlayer.GetComponent<ActionRecorder>().enabled = true;

                presentPlayer = leftPlayer;
                presentPlayerStatic = presentPlayer;
                playerIsNow = PresentPlayer.LEFT;
            } 
            
            else {
                Debug.Log("Left player is dead!");
            }
        }
    }

    public void SelectRightPlayer(KeyCode key)
    {
        if (Input.GetKeyDown(key)) { 
            if(!rightPlayer.GetComponent<PlayerHealth>().playerIsDead){
                DeactivatePresentPlayerComponents();

                rightPlayer.GetComponent<MeshRenderer>().enabled = false;
                rightPlayer.GetComponent<ActionRecorder>().playerHUD.SetActive(true);
                rightPlayer.GetComponentInChildren<MouseLook>().enabled = true;
                rightPlayer.GetComponent<FPSController>().enabled = true;
                rightPlayer.GetComponentInChildren<Camera>().enabled = true;
                rightPlayer.GetComponentInChildren<Rigidbody>().useGravity = false;
                rightPlayer.GetComponentInChildren<GunControl>().enabled = true;
                rightPlayer.GetComponent<ActionRecorder>().enabled = true;

                presentPlayer = rightPlayer;
                presentPlayerStatic = presentPlayer;
                playerIsNow = PresentPlayer.RIGHT;                
            }

            else {
                Debug.Log("Right player is dead!");
            }
        }
    }

    void DeactivatePlayerComponents() {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<ActionRecorder>().playerHUD.SetActive(false);
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

    void DeactivatePresentPlayerComponents(){
        presentPlayer.GetComponentInChildren<Camera>().enabled = false;

        if (presentPlayer != godPlayer)
        {
            presentPlayer.GetComponentInChildren<MouseLook>().enabled = false;
            presentPlayer.GetComponent<FPSController>().enabled = false;
            presentPlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
            presentPlayer.GetComponentInChildren<GunControl>().enabled = false;
            presentPlayer.GetComponent<ActionRecorder>().enabled = true;
            presentPlayer.GetComponent<MeshRenderer>().enabled = true;
            otherPlayerStatic = presentPlayer;
         }

    }



}
