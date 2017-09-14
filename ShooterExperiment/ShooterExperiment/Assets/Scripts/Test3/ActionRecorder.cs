using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRecorder : MonoBehaviour
{
    public enum RecordingState
    {
        RECORDING,
        NOT_RECORDING,
        PLAYBACK
    }

    public KeyCode playKey;
    public KeyCode recordKey;

    public RecordingState recordingState;

    List<Vector3> positions = new List<Vector3>();
    //List<Vector3> rotations = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();

    float t = 1f;

    void Start()
    {
        recordingState = RecordingState.NOT_RECORDING;

    }
    // Update is called once per frame
    void Update()
    {
        ToggleRecord(recordKey);

        if (recordingState != RecordingState.RECORDING)
        {
            PlayRecording(playKey);
        }
    }

    private void FixedUpdate()
    {
 
        if (recordingState == RecordingState.RECORDING)
        {
            RecordMovement(transform.position);
             RecordRotation(transform.rotation);
        }


        if (recordingState == RecordingState.PLAYBACK)
        {
            MoveBasedOnRecording();
            RotateBasedOnRecording();
        }

    }

    private Vector3 posAtRecordStart;
    private int lastRecIndex;

    void ToggleRecord(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            if (recordingState == RecordingState.NOT_RECORDING || recordingState == RecordingState.PLAYBACK)
            {
                recordingState = RecordingState.RECORDING;
                return;
            }
            if (recordingState == RecordingState.RECORDING || recordingState == RecordingState.PLAYBACK)
            {
                recordingState = RecordingState.NOT_RECORDING;
                return;
            }
        }
    }


    void RecordMovement(Vector3 playerPos)
    {
        positions.Add(playerPos);
    }

    private int playbackIndex = 0;

    void MoveBasedOnRecording()
    {
        playbackIndex++;
        Debug.Log(playbackIndex);
        transform.position = positions[playbackIndex];
        if (transform.position == positions[positions.Count-1]) {
            playbackIndex = 0;
            transform.position = positions[0];   
        }
     }

    void PlayRecording(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            recordingState = RecordingState.PLAYBACK;
        }
    }

    //void RecordRotation(Vector3 playerRot) {
    //    rotations.Add(playerRot);
    //}

    void RecordRotation(Quaternion playerRot)
    {
        rotations.Add(playerRot);
    }

    private int rotPlaybackIndex = 0;

    //void RotateBasedOnRecording() {

    //    rotPlaybackIndex++;
    //    transform.rotation = Quaternion.Euler(rotations[rotPlaybackIndex]);
    //    //rotPlaybackIndex++;
    //    //transform.rotation = rotations[rotPlaybackIndex];
    //    if (transform.rotation.eulerAngles == rotations[rotations.Count - 1])
    //    {
    //        rotPlaybackIndex = 0;
    //        transform.rotation = Quaternion.Euler(rotations[0]);
    //    }
    //}

    void RotateBasedOnRecording()
    {
        Debug.Log("this is the quaternion version");
        rotPlaybackIndex++;
        transform.rotation = rotations[rotPlaybackIndex];
         if (transform.rotation == rotations[rotations.Count - 1])
        {
            rotPlaybackIndex = 0;
            transform.rotation = rotations[0];
        }
    }


}
