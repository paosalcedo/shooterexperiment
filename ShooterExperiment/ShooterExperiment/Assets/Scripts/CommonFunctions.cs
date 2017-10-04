using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFunctions : MonoBehaviour {

	public static void ResetPosAndRot(GameObject gameObjectToReset, Vector3 startPos_, Vector3 startEuler_){
		gameObjectToReset.transform.position = startPos_;
		gameObjectToReset.transform.eulerAngles = startEuler_;
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
