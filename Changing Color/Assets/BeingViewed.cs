using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingViewed : MonoBehaviour {
	private List<GameObject> allObjects = new List<GameObject>();
	private Renderer anObjRenderer;
	private Camera cam;
	private Plane[] planes;
	public int timeUntilChange = 5;

	void Start() {
		foreach (var objects in  GameObject.FindObjectsOfType<GameObject>()) {
			allObjects.Add (objects);
		}
		allObjects.Remove (GameObject.Find ("Main Camera"));
		allObjects.Remove (GameObject.Find ("Directional Light"));
		allObjects.Remove (GameObject.Find ("Sun Study"));


		cam = Camera.main;
		planes = GeometryUtility.CalculateFrustumPlanes (cam);
	}

	void Update() {
		//Update where the camera is looking
		planes = GeometryUtility.CalculateFrustumPlanes (cam);

		//Go through every object and see if the camera is looking at it
		for (int i = 0; i < allObjects.Count; i++){
			//Assign current object's renderer to a variable
			anObjRenderer = allObjects[i].GetComponent<Renderer>();


			//Detect if object is in the view of the camera
			if (GeometryUtility.TestPlanesAABB (planes, anObjRenderer.bounds)) {
				//Add one to the count if the object has a count script variable
				if (allObjects[i].GetComponent<Count> () != null) {
					allObjects[i].GetComponent<Count> ().AddOneCount ();
				}

				//When the object has been looked at for a set amount of time, do something
				if ((allObjects[i].GetComponent<Count> ().count % timeUntilChange) == 0) {
					//Change color of the object that is being looked at
					allObjects[i].GetComponent<Renderer> ().material.color = Random.ColorHSV ();
				}

				//Print info when left control is clicked
				if (Input.GetKeyDown (KeyCode.LeftControl)) {
					Debug.Log (allObjects[i].name + " is being looked at");
					Debug.Log (allObjects[i].name + " has been looked at for " + allObjects [i].GetComponent<Count>().count + " seconds");
				}
			}
		}
	}
}

