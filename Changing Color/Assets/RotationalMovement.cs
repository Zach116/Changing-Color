﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour {
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;

    private void Update()
    {
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
        }

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
		}
			
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.Space)){
			transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.LeftShift)){
			transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
		}
    }
}
