using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTrapDoor : MonoBehaviour {

	public GameObject trapDoor1;
	public GameObject trapDoor2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Open(){
		trapDoor1.transform.rotation = Quaternion.AngleAxis (-90, Vector3.right);
		trapDoor2.transform.rotation = Quaternion.AngleAxis (-90, Vector3.left);
		trapDoor1.GetComponent<Collider> ().enabled = false;
		trapDoor2.GetComponent<Collider> ().enabled = false;
	}

	public void Close(){
		trapDoor1.transform.rotation = Quaternion.AngleAxis (0, Vector3.right);
		trapDoor2.transform.rotation = Quaternion.AngleAxis (0, Vector3.left);
	}


}
