using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTrapDoor : MonoBehaviour {

	public GameObject trapDoor1;
	public GameObject trapDoor2;
	Vector3 newRot;
 
	// Use this for initialization
	void Start () {
		newRot = new Vector3(-90f, 0f, 0f); 
 	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Open(){
 //		trapDoor1.transform.rotation = Quaternion.AngleAxis (-90, Vector3.right);
//		trapDoor2.transform.rotation = Quaternion.AngleAxis (-90, Vector3.left);
  	}

	public void Operate(){
		LeanTween.rotate(trapDoor1, Vector3.right, 1f).setEaseInSine().setOnComplete(
			()=>{
				LeanTween.rotate(trapDoor1, newRot, 1f).setEaseInSine().setDelay(3f); 
			}
		);
		LeanTween.rotate(trapDoor2, Vector3.right, 1f).setEaseInSine().setOnComplete(
			()=>{
				LeanTween.rotate(trapDoor2, -newRot, 1f).setEaseInSine().setDelay(3f);
			}
		);  
 //		trapDoor1.transform.rotation = Quaternion.AngleAxis (0, Vector3.right);
//		trapDoor2.transform.rotation = Quaternion.AngleAxis (0, Vector3.left);
		trapDoor1.GetComponent<Collider> ().enabled = true;
		trapDoor2.GetComponent<Collider> ().enabled = true;
	}


}
