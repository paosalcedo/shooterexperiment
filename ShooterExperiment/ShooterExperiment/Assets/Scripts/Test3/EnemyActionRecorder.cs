using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionRecorder : ActionRecorder {

	private List<Vector3> enemyPositions = new List<Vector3>();
	private List<Vector3> enemyRotations = new List<Vector3>();
	private List<bool> enemyAttacks = new List<bool>();

	public bool enemyIsAttacking;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		switch(recordingState){
			case RecordingState.NOT_RECORDING:
					
				break;

			case RecordingState.PLAYBACK:
				PerformActionsBasedOnRecording();
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
		base.PlayRecording(key);
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
