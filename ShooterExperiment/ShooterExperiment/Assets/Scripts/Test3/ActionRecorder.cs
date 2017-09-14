using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRecorder : MonoBehaviour
{

    bool pressed = false;

    public enum RecordingState
    {
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

    void Start()
    {
        recordingState = RecordingState.NOT_RECORDING;

    }

    // Update is called once per frame
    void Update()
    {

        ToggleRecord(recordKey);

        //      if (recordingState != RecordingState.RECORDING) { 
        //          PlayRecording(playKey);
        //      }

        //if (recordingState == RecordingState.RECORDING) {
        //	RecordMovement (transform.position);
        //} 

        //if (recordingState == RecordingState.NOT_RECORDING) {
        //	return;
        //	}

        //if (recordingState == RecordingState.PLAYBACK) {
        //	MoveBasedOnRecording ();
        //}
    }

    private void FixedUpdate()
    {
        Debug.Log("Last rec index: " + lastRecIndex);

        if (recordingState != RecordingState.RECORDING)
        {
            PlayRecording(playKey);
        }

        if (recordingState == RecordingState.RECORDING)
        {
            RecordMovement(transform.position);
        }

        if (recordingState == RecordingState.NOT_RECORDING)
        {
            return;
        }

        if (recordingState == RecordingState.PLAYBACK)
        {
            MoveBasedOnRecording();
        }

        if (playbackIndex >= positions.Count)
        {
            recordingState = RecordingState.NOT_RECORDING;
        }

    }

    private Vector3 posAtRecordStart;
    private int lastRecIndex;

    void ToggleRecord(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            posAtRecordStart = transform.position;

            if (recordingState == RecordingState.NOT_RECORDING || recordingState == RecordingState.PLAYBACK)
            {
                recordingState = RecordingState.RECORDING;
                return;
            }
            if (recordingState == RecordingState.RECORDING || recordingState == RecordingState.PLAYBACK)
            {
                recordingState = RecordingState.NOT_RECORDING;
                lastRecIndex = positions.Count - 1;
                return;
            }
        }
    }


    void RecordMovement(Vector3 playerPos)
    {
        positions.Add(playerPos);
    }

    float w = 0.1f;

    private int playbackIndex = 0;

    void MoveBasedOnRecording()
    {
        playbackIndex++;
        Debug.Log(playbackIndex);
        transform.position = positions[playbackIndex];
    }

    void PlayRecording(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            recordingState = RecordingState.PLAYBACK;
        }
    }


}
