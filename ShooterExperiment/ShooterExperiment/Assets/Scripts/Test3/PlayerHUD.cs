using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public Image recordBar; //recording time remaining 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void UpdateRecordBar(float time) {
        recordBar.fillAmount = time/5f;
    }
}
