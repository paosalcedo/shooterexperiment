using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRecorder : MonoBehaviour {

	bool pressed = false;

	public enum RecordingState{
		RECORDING,
		NOT_RECORDING,
		PLAYBACK
	}

	public KeyCode playKey;
	public KeyCode recordKey;

	public RecordingState recordingState;

	public List<Vector3> positions = new List<Vector3>();
	// Use this for initialization

	float t = 1f;

	void Start () {
		recordingState = RecordingState.NOT_RECORDING;

	}
	
	// Update is called once per frame
	void Update () {

		ToggleRecord (recordKey);
		PlayRecording (playKey);

		if (recordingState == RecordingState.RECORDING) {
			RecordMovement (transform.position);
		} 

		if (recordingState == RecordingState.NOT_RECORDING) {
			return;
 		}

		if (recordingState == RecordingState.PLAYBACK) {
			MoveBasedOnRecording ();
		}
	}

	void ToggleRecord(KeyCode key){
		if(Input.GetKeyDown(key)){
			posAtRecordStart = transform.position;

			if (recordingState == RecordingState.NOT_RECORDING || recordingState == RecordingState.PLAYBACK) {
				recordingState = RecordingState.RECORDING;
				return;
			}
			if (recordingState == RecordingState.RECORDING || recordingState == RecordingState.PLAYBACK) {
				recordingState = RecordingState.NOT_RECORDING;
 				return;
			}
		}
	}

	private Vector3 posAtRecordStart;

	void RecordMovement(Vector3 playerPos){
		t -= Time.deltaTime;
		if (t <= 0) {
			positions.Add (playerPos);
			t = 1f;
		}
	}

	float w = 0.1f;

	private int nextIndex = 0;

	void MoveBasedOnRecording(){
		w -= Time.deltaTime;
		if (w <= 0) {
			nextIndex++;
			w = 1f;
		}
		transform.position = positions [nextIndex];
	}

	void PlayRecording(KeyCode key){
		if (Input.GetKeyDown (key)) {
			recordingState = RecordingState.PLAYBACK;
		}
	}

	
}
