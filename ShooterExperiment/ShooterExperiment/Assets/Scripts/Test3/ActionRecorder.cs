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

    public GameObject thisCamera;

    public KeyCode playKey;
    public KeyCode recordKey;
    private float timeFired;

    public RecordingState recordingState;

    public bool isAttacking = false; 

    private float attackRecordTime = 0; 
    List<bool> attacks = new List<bool>();
    List<Vector3> positions = new List<Vector3>();
    List<Vector3> rotations = new List<Vector3>();
    //List<Quaternion> rotations = new List<Quaternion>();

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        if (recordingState == RecordingState.RECORDING)
        {
            RecordMovement(transform.position);
            //RecordRotation(transform.rotation);
            RecordRotation(transform.eulerAngles);
            RecordWeaponActivity(isAttacking);
        }


        if (recordingState == RecordingState.PLAYBACK)
        {
            MoveBasedOnRecording();
            RotateBasedOnRecording();
            AttackBasedOnRecording();
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
        Debug.Log("Movement index: " + playbackIndex);
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

    void RecordRotation(Vector3 playerRot)
    {
        rotations.Add(playerRot);
    }

    //void RecordRotation(Quaternion playerRot)
    //{
    //    rotations.Add(playerRot);
    //}

    private int rotPlaybackIndex = 0;

    //void RotateBasedOnRecording() {

    void RotateBasedOnRecording()
    {
        Debug.Log("this is the quaternion version");
        rotPlaybackIndex++;
        transform.eulerAngles = rotations[rotPlaybackIndex];
        if (transform.eulerAngles == rotations[rotations.Count - 1])
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

    void RecordWeaponActivity (bool isAttacking_)
	{
        //attackRecordTime += Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Mouse0)) {
        //    timeFired = attackRecordTime;
        //}
        attacks.Add(isAttacking_);
    }

    private int attackIndex = 0;

    void AttackBasedOnRecording() {
        Debug.Log("Attack index: " + attackIndex);
        attackIndex++;
        isAttacking = attacks[attackIndex];

        if (isAttacking) {
            if(this.gameObject.tag == "Player2") {
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Weapons/RedBullet")) as GameObject;
                //				Debug.Log (gameObject.name + " is attacking!");
                bullet.transform.position = transform.position;
                //				bullet.GetComponent<MeshRenderer>().enabled = false;
                bullet.transform.rotation = transform.rotation;
            }

            if (this.gameObject.tag == "Player")
            {
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Weapons/BlueBullet")) as GameObject;
                //				Debug.Log (gameObject.name + " is attacking!");
                bullet.transform.position = transform.position;
                //				bullet.GetComponent<MeshRenderer>().enabled = false;
                bullet.transform.rotation = transform.rotation;
            }

        }

        if (attackIndex == attacks.Count-1) {
            attackIndex = 0;
            isAttacking = false;
        }
    }
	

}
