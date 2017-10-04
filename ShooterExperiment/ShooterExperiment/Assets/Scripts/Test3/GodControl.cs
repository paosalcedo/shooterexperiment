using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodControl : PlayerSwitcherScript {
    public GameObject godHUD;

    public bool midIsPlaying;
    public bool rightIsPlaying;
    public bool leftIsPlaying;
    public bool godIsSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (godIsSelected) { 
            PlayMidPlayerRecording();
            PlayRightPlayerRecording();
            PlayLeftPlayerRecording();
        }
    }

    void PlayMidPlayerRecording() {
        if (midIsPlaying)
        {
            midPlayer.GetComponent<ActionRecorder>().recordingState = ActionRecorder.RecordingState.PLAYBACK;
        }
        else {
            midPlayer.GetComponent<ActionRecorder>().recordingState = ActionRecorder.RecordingState.NOT_RECORDING;
        }
    }

    void PlayLeftPlayerRecording() {
        if (leftIsPlaying){
            leftPlayer.GetComponent<ActionRecorder>().recordingState = ActionRecorder.RecordingState.PLAYBACK;
        } else
        {
            leftPlayer.GetComponent<ActionRecorder>().recordingState = ActionRecorder.RecordingState.NOT_RECORDING;
        }
    }

    void PlayRightPlayerRecording() {
        if (rightIsPlaying) {
            rightPlayer.GetComponent<ActionRecorder>().recordingState = ActionRecorder.RecordingState.PLAYBACK;
        } else
        {
            rightPlayer.GetComponent<ActionRecorder>().recordingState = ActionRecorder.RecordingState.NOT_RECORDING;
        }
    }

    public void MidTogglePlay (GodControl godControl)
    {
        godControl.midIsPlaying = !godControl.midIsPlaying;
        midIsPlaying = godControl.midIsPlaying;
     }

    public void LeftTogglePlay(GodControl godControl)
    {
        godControl.leftIsPlaying = !godControl.leftIsPlaying;
        leftIsPlaying = godControl.leftIsPlaying;
     }

    public void RightTogglePlay(GodControl godControl)
    {
        godControl.rightIsPlaying = !godControl.rightIsPlaying;
        rightIsPlaying = godControl.rightIsPlaying;
    }

    public void AllTogglePlay(GodControl godControl){
        godControl.midIsPlaying = !godControl.midIsPlaying;
        midIsPlaying = godControl.midIsPlaying;
        godControl.rightIsPlaying = !godControl.rightIsPlaying;
        rightIsPlaying = godControl.rightIsPlaying;
        godControl.leftIsPlaying = !godControl.leftIsPlaying;
        leftIsPlaying = godControl.leftIsPlaying;
        GameStateControl.gameState = GameStateControl.GameState.LIVE;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        foreach (GameObject enemy in enemies){
            enemy.GetComponent<EnemyActionRecorder>().ResetEnemyPosAndRot();
            enemy.GetComponent<EnemyActionRecorder>().recordingState = EnemyActionRecorder.RecordingState.PLAYBACK; 
        }

    }
    
}
