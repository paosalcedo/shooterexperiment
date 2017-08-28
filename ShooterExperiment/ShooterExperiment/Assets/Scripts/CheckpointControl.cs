using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControl : MonoBehaviour {
 
	public static Dictionary<int, GameObject> chkDict = new Dictionary<int, GameObject>();
	
	public static int chkLast;

	public static Dictionary<int, GameObject> chkDictP2 = new Dictionary<int, GameObject>();

	public static int chkLastP2;

}
