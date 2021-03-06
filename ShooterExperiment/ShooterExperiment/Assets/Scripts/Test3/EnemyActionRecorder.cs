﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionRecorder : MonoBehaviour {

	private List<Vector3> enemyPositions = new List<Vector3>();
	private List<Vector3> enemyRotations = new List<Vector3>();
	private List<bool> enemyAttacks = new List<bool>();

	Rigidbody rb;

	int enemyPlaybackIndex = 0;

	public bool enemyIsAttacking = false;

	private Vector3 startPos;
	private Vector3 startEuler;
	// Use this for initialization
	public void Start () {
		// base.Start();
		rb = GetComponent<Rigidbody>();
		startPos = transform.position;
		startEuler = transform.eulerAngles;
		// recordingState = RecordingState.NOT_RECORDING;
	}
	
 	// Update is called once per frame
	void Update () {	

		// base.ToggleRecord(recordKey);

		// Debug.Log("Target is " + recordingState);
		// if(Input.GetKeyDown(KeyCode.E)){
		// 	CommonFunctions.ResetPosAndRot(this.gameObject, startPos, startEuler);
		// }

		// if (recordingState != RecordingState.RECORDING)
        // {
        //     PlayRecording(playKey);
        // }
        
        // if (recordingState == RecordingState.RECORDING){
        // 	recordTime -= Time.deltaTime;
        // }
	
		// if(recordingState == RecordingState.NOT_RECORDING){
		// 	ResetRecordTime();
        // }
	}

	// void FixedUpdate(){
	// 	switch(recordingState){
	// 		case RecordingState.NOT_RECORDING:
	// 			ResetRecordTime();
	// 			break;

	// 		case RecordingState.PLAYBACK:
	// 			PerformActionsBasedOnRecording();
	// 			// rb.isKinematic = true;
	// 			break;

	// 		case RecordingState.RECORDING:
	// 			if(recordTime>=0){
	// 				Record(transform.position, transform.eulerAngles, enemyIsAttacking);		
	// 			} else {

	// 				recordingState = RecordingState.NOT_RECORDING;
	// 			}
	// 			break;

	// 		default:
	// 			break;
	// 	}
	// }


	public void Record(Vector3 pos_, Vector3 rot_, bool enemyIsAttacking_){
		enemyPositions.Add(pos_);	
		enemyRotations.Add(rot_);
		enemyAttacks.Add(enemyIsAttacking_);
	}

	// public override void PlayRecording(KeyCode key){
	// 	if(Input.GetKeyDown(key)){
	// 		// recordingState = RecordingState.PLAYBACK;
	// 	}
	// }

	public void PerformActionsBasedOnRecording(){
		if(enemyPlaybackIndex < enemyPositions.Count-1)
        {
			enemyPlaybackIndex++;
            transform.position = enemyPositions[enemyPlaybackIndex];
			transform.eulerAngles = enemyRotations[enemyPlaybackIndex];
			// isAttacking = enemyAttacks[enemyPlaybackIndex];
        }
        else if(enemyPlaybackIndex == enemyPositions.Count - 1) {
            // recordingState = RecordingState.NOT_RECORDING;
			enemyPlaybackIndex = 0;
			transform.position = enemyPositions[enemyPlaybackIndex];
			transform.eulerAngles = enemyRotations[enemyPlaybackIndex];
			// isAttacking = enemyAttacks[enemyPlaybackIndex];
        }
	}

	public void ResetEnemyPosAndRot(){
		CommonFunctions.ResetPosAndRot(this.gameObject, startPos, startEuler);
	}




	
}
