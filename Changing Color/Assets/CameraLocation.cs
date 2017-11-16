using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocation : MonoBehaviour {
	Vector3 currentPos;
	// Use this for initialization
	void Start () {
		currentPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		currentPos = transform.position;

		//Print info when space is clicked
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("The camera is located at " + currentPos);
		}
	}
}
