using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingViewed : MonoBehaviour {
	private List<GameObject> allObjects = new List<GameObject>();
	private Collider anObjCollider;
	private Camera cam;
	private Plane[] planes;
	public int timeUntilChange = 5;

	void Start() {
		foreach (var objects in  GameObject.FindObjectsOfType<GameObject>()) {
			allObjects.Add (objects);
		}
		allObjects.Remove (GameObject.Find ("Main Camera"));
		allObjects.Remove (GameObject.Find ("Directional Light"));

		cam = Camera.main;
		planes = GeometryUtility.CalculateFrustumPlanes (cam);
	}

	void Update() {
		//Update where the camera is looking
		planes = GeometryUtility.CalculateFrustumPlanes (cam);

		//Go through every object and see if the camera is looking at it
		for (int i = 0; i < allObjects.Count; i++){
			//Assign current object's collider to a variable
			anObjCollider = allObjects[i].GetComponent<Collider>();

			//Detect if object is in the view of the camera
			if (GeometryUtility.TestPlanesAABB (planes, anObjCollider.bounds) && ((allObjects[i].GetComponent<Count>().count % timeUntilChange) == 0)) {
				//Change color of the object that is being looked at
				allObjects[i].GetComponent<Renderer>().material.color = Random.ColorHSV();

				//Add one to the count if the object has a count script variable
				if (allObjects[i].GetComponent<Count> () != null) {
					allObjects[i].GetComponent<Count> ().AddOneCount ();
				}

				//Print info when space is clicked
				if (Input.GetKeyDown (KeyCode.LeftControl)) {
					Debug.Log (allObjects[i].name + " is being looked at");
					Debug.Log (allObjects[i].name + " has been looked at for " + allObjects [i].GetComponent<Count>().count + " seconds");
				}
			}
		}
	}
}

