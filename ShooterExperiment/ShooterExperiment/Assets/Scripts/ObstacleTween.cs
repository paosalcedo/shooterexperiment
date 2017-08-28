using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTween : MonoBehaviour {
	
	public float delay;
	// Use this for initialization
	void Start () {
		LeanTween.moveLocalY(this.gameObject, 20, 1.5f).setEaseInSine().setLoopPingPong().setDelay(delay);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
