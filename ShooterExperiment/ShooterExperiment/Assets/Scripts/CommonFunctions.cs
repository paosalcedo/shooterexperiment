using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFunctions : MonoBehaviour {

	public static void ResetPosAndRot(GameObject gameObjectToReset, Vector3 startPos_, Vector3 startEuler_){
		gameObjectToReset.transform.position = startPos_;
		gameObjectToReset.transform.eulerAngles = startEuler_;
	}


}
