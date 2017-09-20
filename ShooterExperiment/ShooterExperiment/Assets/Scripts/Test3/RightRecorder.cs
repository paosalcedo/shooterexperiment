using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRecorder : MonoBehaviour

{
    public GameObject playerHUD;


    public enum RecordingState
    {
        RECORDING,
        NOT_RECORDING,
        PLAYBACK
    }

    public enum AttackState
    {
        ATTACKING,
        NOT_ATTACKING
    }

    public GameObject thisCamera;

    public KeyCode playKey;
    public KeyCode recordKey;
    private float timeFired;

    private int playbackIndex = 0;
    private int attackIndex = 0;
    private int rotPlaybackIndex = 0;

    private float maxRecordTime = 0;
    [SerializeField]
    float recordTime = 5;

    public RecordingState recordingState;

    public bool isAttacking = false;
    public bool isSelected;

    List<bool> attacks = new List<bool>();
    List<Vector3> positions = new List<Vector3>();
    List<Vector3> rotations = new List<Vector3>();

    float t = 1f;

    void Start()
    {
        isSelected = false;
        maxRecordTime = recordTime;
        recordingState = RecordingState.NOT_RECORDING;
    }
    // Update is called once per frame
    void Update()
    {
        //update recording bar

        playerHUD.GetComponentInChildren<PlayerHUD>().UpdateRecordBar(recordTime, maxRecordTime);

        //Debug.Log("attack: " + attackIndex + " rotation: " + rotPlaybackIndex + " movement: " + playbackIndex);

        ToggleRecord(recordKey);

        if (recordingState != RecordingState.RECORDING)
        {
            PlayRecording(playKey);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        //add time to recordTime
        if (recordingState == RecordingState.RECORDING)
        {
            recordTime -= Time.deltaTime;
        }

    }
    //update runs unbounded
    //25-60 fps
    //lerp to each frame in the list
    //add a little bit of easing to the movements;
    //try DOTween and record all positions as places to go; moveTo, RotateBy, 
    //if fixed timestep is not set oorrecctly, might look weird. Fixed timestep should be set so you're running at 60 fps. 



    private void FixedUpdate()
    {

        if (recordingState == RecordingState.RECORDING)
        {
            if (recordTime >= 0)
            {
                RecordMovement(transform.position);
                RecordRotation(transform.eulerAngles);
                RecordWeaponActivity(isAttacking);
            }
            else
            {
                Debug.Log(this.gameObject + "is not recording!");
                recordingState = RecordingState.NOT_RECORDING;
            }
        }

        if (recordingState == RecordingState.PLAYBACK)
        {
            MoveBasedOnRecording();
            RotateBasedOnRecording();
            AttackBasedOnRecording();
        }

    }


    void ToggleRecord(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("record key pressed");
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


    void MoveBasedOnRecording()
    {
        playbackIndex++;
        transform.position = positions[playbackIndex];
        //if (transform.position == positions[positions.Count-1]) {
        if (playbackIndex == positions.Count - 1)
        {
            playbackIndex = 0;
            transform.position = positions[0];
        }
    }

    void PlayRecording(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            recordingState = RecordingState.PLAYBACK;
            Debug.Log(this.gameObject.name + " is playing a recording");
        }
    }

    void RecordRotation(Vector3 playerRot)
    {
        rotations.Add(playerRot);
        Debug.Log(this.gameObject.name + " is recording!");
    }

    //void RecordRotation(Quaternion playerRot)
    //{
    //    rotations.Add(playerRot);
    //}


    //void RotateBasedOnRecording() {

    void RotateBasedOnRecording()
    {
        rotPlaybackIndex++;
        transform.eulerAngles = rotations[rotPlaybackIndex];
        if (rotPlaybackIndex == rotations.Count - 1)
        {
            rotPlaybackIndex = 0;
            transform.eulerAngles = rotations[0];
        }
    }

    //void RotateBasedOnRecording()
    //{
    //    Debug.Log("this is the quaternion version");
    //    rotPlaybackIndex++;
    //    transform.rotation = rotations[rotPlaybackIndex];
    //     if (transform.rotation == rotations[rotations.Count - 1])
    //    {
    //        rotPlaybackIndex = 0;
    //        transform.rotation = rotations[0];
    //    }
    //}

    void RecordWeaponActivity(bool isAttacking_)
    {
        attacks.Add(isAttacking_);
    }


    void AttackBasedOnRecording()
    {
        attackIndex++;
        isAttacking = attacks[attackIndex];

        if (isAttacking)
        {
            if (gameObject.tag == "Player2")
            {
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Weapons/RedBullet")) as GameObject;
                bullet.transform.position = thisCamera.transform.position;
                bullet.transform.rotation = thisCamera.transform.rotation;
            }

            if (gameObject.tag == "Player")
            {
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Weapons/BlueBullet")) as GameObject;
                bullet.transform.position = thisCamera.transform.position;
                bullet.transform.rotation = thisCamera.transform.rotation;
            }

        }

        if (attackIndex == attacks.Count - 1)
        {
            attackIndex = 0;
            isAttacking = false;
        }
    }

    public void IsSelected(ActionRecorder script)
    {
        script.isSelected = !script.isSelected;
        isSelected = script.isSelected;
        Debug.Log("heyyy it's " + this.gameObject.name + " " + isSelected);
    }

}