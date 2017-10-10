using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionRecorder : MonoBehaviour
{
    protected GameObject godHUD;
    public GameObject gameManager;
    public GameObject playerHUD;
    public enum RecordingState
    {
        RECORDING,
        NOT_RECORDING,
        PLAYBACK
    }

    public GameObject thisCamera;

    [SerializeField]LayerMask playerLayer;
    public KeyCode playKey;
    public KeyCode recordKey;
    private float timeFired;

    private int playbackIndex = 0;
    private int attackIndex = 0;
    private int rotPlaybackIndex = 0;

    private int rotXplaybackIndex = 0;

    private float maxRecordTime = 0;
    public float recordTime = 5;

    public RecordingState recordingState;

    public bool isAttacking = false;
    public bool isSelected;

    //Lists for recording
    List<bool> attacks = new List<bool>();
    List<Vector3> positions = new List<Vector3>();
    List<Vector3> rotations = new List<Vector3>();
    List<float> xRotations = new List<float>();

    private Vector3 startPos;
    private Vector3 startEuler;

    private Toggle allTogglePlay;
    void Awake(){
        isSelected = false;
    }
    public virtual void Start() {
        godHUD = GameObject.Find("GodCanvas");
        allTogglePlay = godHUD.GetComponentInChildren<Toggle>();
        maxRecordTime = recordTime;
        recordingState = RecordingState.NOT_RECORDING;
        startEuler = transform.eulerAngles;
        startPos = transform.position;
     }
    // Update is called once per frame
    void Update()
    {
        //update recording bar

        // Debug.Log("Tank is " + recordingState);

        playerHUD.GetComponentInChildren<PlayerHUD>().UpdateBar(recordTime,maxRecordTime);

 
        //Debug.Log("attack: " + attackIndex + " rotation: " + rotPlaybackIndex + " movement: " + playbackIndex);

        // ToggleRecord(recordKey);
        PlayRecording(playKey);
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            isAttacking = true;
        }
        else {
            isAttacking = false;
        }

        //add time to recordTime
        if (recordingState == RecordingState.RECORDING) {
            recordTime -= Time.deltaTime;
        }

    }
    //update runs unbounded
    //25-60 fps
    //lerp to each frame in the list
    //add a little bit of easing to the movements;
    //try DOTween and record all positions as places to go; moveTo, RotateBy, 
    //if fixed timestep is not set oorrecctly, might look weird. Fixed timestep should be set so you're running at 60 fps. 

   

    void FixedUpdate()
    {

        switch(recordingState){
            case RecordingState.RECORDING:
                if (recordTime >= 0)
                {   //RECORDING happens here
                    GameStateControl.gameState = GameStateControl.GameState.SIMULATION;
                    RecordMovement(transform.position);
                    RecordRotation(transform.eulerAngles, thisCamera.transform.eulerAngles.x);
                    RecordWeaponActivity(isAttacking);
                }
                else {
                    CommonFunctions.ResetPosAndRot(gameObject, startPos, startEuler);
                    recordingState = RecordingState.NOT_RECORDING;
                }
                break;
            case RecordingState.PLAYBACK:
                // GameStateControl.gameState = GameStateControl.GameState.LIVE;
                // Debug.Log(this.gameObject.name + " is in playback mode");
            //check if player is alive before moving.
                if(!GetComponent<PlayerHealth>().playerIsDead){
                    MoveBasedOnRecording();
                    RotateBasedOnRecording();
                    AttackBasedOnRecording();
                }
                break;

            case RecordingState.NOT_RECORDING:
                ResetRecordTime();
                ToggleRecord(recordKey);
                GameStateControl.gameState = GameStateControl.GameState.SIMULATION;
                break;
            
            default:
                break;
        }

    }

    public virtual void ToggleRecord(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
             if (recordingState == RecordingState.NOT_RECORDING)
            {
                recordingState = RecordingState.RECORDING;
                return;
            }
            if (recordingState == RecordingState.RECORDING)
            {
                recordingState = RecordingState.NOT_RECORDING;
                return;
            }
        }
    }


    public virtual void RecordMovement(Vector3 playerPos){
        if(PlayerSwitcherScript.presentPlayerStatic == this.gameObject){
            positions.Add(playerPos);        
        }
    }

    public void StopPlayback(){
        recordingState = RecordingState.NOT_RECORDING;        
    }
    public virtual void PlayRecording(KeyCode key){
        if (Input.GetKeyDown(key)) { 
             if(this.gameObject != PlayerSwitcherScript.presentPlayerStatic){
                recordingState = RecordingState.PLAYBACK;
             }  
        }
    }

    
    public virtual void RecordRotation(Vector3 playerRot, float playerRotX)
    {
        if(PlayerSwitcherScript.presentPlayerStatic == this.gameObject){
            rotations.Add(playerRot);
            xRotations.Add(playerRotX);
        }
    }

    //void RecordRotation(Quaternion playerRot)
    //{
    //    rotations.Add(playerRot);
    //}

    public virtual void RecordWeaponActivity (bool isAttacking_)
	{        
        if(PlayerSwitcherScript.presentPlayerStatic == this.gameObject){
            attacks.Add(isAttacking_);
        }
    }

    public virtual void MoveBasedOnRecording()
    { 
        if(playbackIndex < positions.Count-1){
            playbackIndex++;
            transform.position = positions[playbackIndex];
        }
        //if (transform.position == positions[positions.Count-1]) {
        else if(playbackIndex == positions.Count - 1) {
            recordingState = RecordingState.NOT_RECORDING;  
            allTogglePlay.isOn = false;
            //add these back in if you want the recording to loop
            playbackIndex = 0;
            transform.position = positions[playbackIndex];
            Debug.Log("loop should end here!");
        }
     }
    
    
    public virtual void RotateBasedOnRecording() {
        if(rotPlaybackIndex < rotations.Count-1){
            rotPlaybackIndex++;
            transform.eulerAngles = new Vector3(0, rotations[rotPlaybackIndex].y, 0);
            thisCamera.transform.eulerAngles = new Vector3(xRotations[rotPlaybackIndex], rotations[rotPlaybackIndex].y , 0);
        }

        else if (rotPlaybackIndex == rotations.Count - 1)
        {
            recordingState = RecordingState.NOT_RECORDING;  
            //add these back in if you want the recording to loop
            rotPlaybackIndex = 0;
            transform.eulerAngles = rotations[rotPlaybackIndex];
        }
    }
   
    //Instantiates the player's bullets 
    public virtual void AttackBasedOnRecording() {
        if(attackIndex < attacks.Count-1){
            attackIndex++;
            isAttacking = attacks[attackIndex];
        } else if (attackIndex == attacks.Count-1) {
            recordingState = RecordingState.NOT_RECORDING;  
            attackIndex = 0;
            isAttacking = false;
        } 

        if (isAttacking) {
            if(gameObject.name == "Laser") {
                Ray ray = new Ray(thisCamera.transform.position, thisCamera.transform.forward);
                Transform laserTarget;
		        RaycastHit rayHit = new RaycastHit();

                if(Physics.Raycast (ray, out rayHit, Mathf.Infinity, playerLayer)){
                    if(rayHit.transform.name != "Laser"){
                        laserTarget = rayHit.transform;
                        GameObject hitEffect; 
                        hitEffect = Instantiate(Resources.Load("Prefabs/Effects/LaserHit") as GameObject);
                        hitEffect.transform.position = rayHit.point;
                         // hitEffect = Instantiate(Services.Prefabs.LaserHit, rayHit.point, Quaternion.identity);
                        // hitEffect = Instantiate(Resources.Load("Prefabs/Effects/LaserHit") as GameObject);

                        if(rayHit.transform.tag == "Enemies"){
                            var enemy = rayHit.transform;
                            // Debug.Log("PLAYBACK RAY sent!");
                            enemy.SendMessage("DeductHealth", 20f); 
                        }
                    }
		        }
                 // GameObject bullet = Instantiate(Resources.Load("Prefabs/Weapons/LaserBullet")) as GameObject;
                //  bullet.transform.position = thisCamera.transform.position;
                //  bullet.transform.rotation = thisCamera.transform.rotation;
            }

            if (gameObject.name == "MineMaster")
            {
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Weapons/Mine")) as GameObject;
                 bullet.transform.position = thisCamera.transform.position;
                 bullet.transform.rotation = thisCamera.transform.rotation;
            }

            if (gameObject.name == "Tank")
            {
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Weapons/MortarBullet")) as GameObject;
                 bullet.transform.position = thisCamera.transform.position;
                 bullet.transform.rotation = thisCamera.transform.rotation;
            }

        }

        
    }

    void IsSelected(ActionRecorder script) {
        script.isSelected = !script.isSelected;
        isSelected = script.isSelected;
        Debug.Log("heyyy it's " + this.gameObject.name + " " + isSelected);
    }

    public void ResetRecordTime(){
        recordTime = maxRecordTime;
    }

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "RecordingTrigger"){
            if (recordingState == RecordingState.NOT_RECORDING){
                recordingState = RecordingState.RECORDING;
                return;
            }
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.gameObject.tag == "RecordingTrigger"){
            if (recordingState == RecordingState.RECORDING){
                recordingState = RecordingState.NOT_RECORDING;
                return;
            }
        }
    }

}
