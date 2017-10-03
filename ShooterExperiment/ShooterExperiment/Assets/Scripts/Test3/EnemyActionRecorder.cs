using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionRecorder : ActionRecorder {

	private List<Vector3> enemyPositions = new List<Vector3>();
	private List<Vector3> enemyRotations = new List<Vector3>();
	private List<bool> enemyAttacks = new List<bool>();

	Rigidbody rb;

	public bool enemyIsAttacking;

	// Use this for initialization
	public override void Start () {
		base.Start();
		rb = GetComponent<Rigidbody>();
	}
	
 	// Update is called once per frame
	void Update () {	

		base.ToggleRecord(recordKey);

		if (recordingState != RecordingState.RECORDING)
        {
            PlayRecording(playKey);
        }
        
        if (recordingState == RecordingState.RECORDING){
        	recordTime -= Time.deltaTime;
        }
		
		if(recordingState == RecordingState.NOT_RECORDING){
			ResetRecordTime();
        }
	}

	void FixedUpdate(){
		switch(recordingState){
			case RecordingState.NOT_RECORDING:
				ResetRecordTime();
				break;

			case RecordingState.PLAYBACK:
				PerformActionsBasedOnRecording();
				rb.isKinematic = true;
				break;

			case RecordingState.RECORDING:
				Record(transform.position, transform.eulerAngles, enemyIsAttacking);		
				break;

			default:
				break;
		}
	}

	public void Record(Vector3 pos_, Vector3 rot_, bool enemyIsAttacking_){
		enemyPositions.Add(pos_);	
		enemyRotations.Add(rot_);
		enemyAttacks.Add(enemyIsAttacking_);
	}

	public override void PlayRecording(KeyCode key){
		if(Input.GetKeyDown(key)){
			recordingState = RecordingState.PLAYBACK;
		}
	}

	public void PerformActionsBasedOnRecording(){
        int playbackIndex = 0;
		if(playbackIndex < enemyPositions.Count-1)
        {
            playbackIndex++;
            transform.position = enemyPositions[playbackIndex];
			transform.eulerAngles = enemyRotations[playbackIndex];
			isAttacking = enemyAttacks[playbackIndex];
        }
        else if(playbackIndex == enemyPositions.Count - 1) {
            recordingState = RecordingState.NOT_RECORDING;  
        }
	}





	
}
