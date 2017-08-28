using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTween : MonoBehaviour {
	
	public float delay;
	public uint uid;
	public uint uglobalid;
	// Use this for initialization
	void Start () {
		LeanTween.moveLocalY(this.gameObject, 20, 0.5f).setEaseInSine().setLoopPingPong().setDelay(delay).setId(uid, 0);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseTween(){
		LeanTween.pause (this.gameObject);
//		LeanTween.pauseAll ();
	}

	public void ResumeTween(){
		LeanTween.resume (this.gameObject);
	}


}
