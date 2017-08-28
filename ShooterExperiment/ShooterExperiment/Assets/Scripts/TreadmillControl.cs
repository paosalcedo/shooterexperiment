using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillControl : MonoBehaviour {

	public GameObject crusher1;
	public GameObject crusher2;
	public GameObject crusher3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		crusher1.SendMessage ("PauseTween");
		crusher2.SendMessage ("PauseTween");
		crusher3.SendMessage ("PauseTween");
	}

	void OnTriggerExit(){
		crusher1.SendMessage ("ResumeTween");
		crusher2.SendMessage ("ResumeTween");
		crusher3.SendMessage ("ResumeTween");
	}



}
