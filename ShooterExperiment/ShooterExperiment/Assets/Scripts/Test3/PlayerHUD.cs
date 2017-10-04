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

    public virtual void UpdateBar(float currentValue, float maxValue) {
        //float remappedTime = remapRange(time, 0, maxTime, 0, 1);

        recordBar.fillAmount = currentValue/maxValue;
       
    }

    public static float remapRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax)
    {
        float newValue = 0;
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
        return newValue;
    }



}
